module morse_code (input [1:0]KEY, input [2:0]SW, input CLOCK_50, output [0:0]LEDR);
	wire [3:0] len; 
	wire [3:0] M; 
	wire enable; 
	
	letter_selection (SW[2:0], M[3:0], len[3:0]);
	counter (CLOCK_50, enable);
	state_table (KEY[1], KEY[0], M[3:0], len[3:0], CLOCK_50, enable, LEDR[0]);

endmodule

module state_table (input x, input y, input [3:0]M, input [3:0]len, input clk, input enable, output [0:0]Q); 

	reg [3:0] lenC; 
	reg [2:0] yQ, yD; // current and next state of fsm
	reg [3:0] M_; // left-most bit processed each time
	
	parameter a = 3'b000, b = 3'b001, c = 3'b010, d = 3'b011, e = 3'b100;
	
	// state table
	always @(*) begin
		case (yQ)
			a: if (!x) 
					yD = b;
				else
					yD = a;
					
			b: if (M_[3])
					yD = c;        // b -> c -> d -> e = 0.5 + 0.5 + 0.5 = 1.5 seconds 'dash'
				else
					yD = e;        // b -> e = 0.5 seconds 'dot'
				
			c: yD = d;
			
			d: yD = e;
			
			e: if (!lenC[3])
					yD = a; 
				else
					yD = b;
					
			default: yD = 3'b000;
			endcase
		end

		always @(posedge clk) begin
			if (enable) begin
				yQ <= yD;
				
				if (yD == a) begin
					lenC <= len;
					M_ <= M;
				end
				
				if (!y)
					yQ <= a;
				else 
					if (yD == e) begin
					M_[3] <= M_[2];    
					M_[2] <= M_[1];
					M_[1] <= M_[0];
					M_[0] <= 1'b0;
					lenC[3] <= lenC[2]; //zmiejsza dł o 1 po kazdym impulsie
					lenC[2] <= lenC[1];
					lenC[1] <= lenC[0];
					lenC[0] <= 1'b0;
				end
			end
		end
		
		
	// assigns outbit
	assign Q[0] = (yQ == b) | (yQ == c) | (yQ == d); 
		
endmodule

module letter_selection (input [2:0] x, output reg[3:0] M, output reg[3:0] len);
// definiuje wzory myślników / kropek dla liter i długości ich sekwencji

  
	parameter A = 3'b000, B = 3'b001, C = 3'b010, D = 3'b011, E = 3'b100, F = 3'b101, G = 3'b110, H = 3'b111;

	always @(x) begin
		case (x)
			A: begin
				M = 4'b0100;
				len = 4'b1100; 
				end
			B: begin
				M = 4'b1000;
				len = 4'b1111; 
				end
			C: begin
				M = 4'b1010;
				len = 4'b1111; 
				end
			D: begin
				M = 4'b1000;
				len = 4'b1110; 
				end
			E: begin
				M = 4'b0000;
				len = 4'b1000; 
				end
			F: begin
				M = 4'b0010;
				len = 4'b1111; 
				end
			G: begin
				M = 4'b1100;
				len = 4'b1110; 
				end
			H: begin
				M = 4'b0000;
				len = 4'b1111; 
				end
		endcase
	end
	
endmodule

module counter(input clk, output reg enable); // konwersja 50 MHz na półsekundowe cykle ZEGARA
	reg [24:0]counter;
	
	always @(posedge clk)
		if (counter ==  5) begin // 5000000/2
			counter <= 0;
			enable <= 1;
		end
		else begin
			counter <= counter + 1;
			enable <= 0;
		end
endmodule