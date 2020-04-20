module counter_BCD_3_digits(
input CLOCK_50,
input [0:0] KEY, 
output [0:6] HEX0, HEX1, HEX2,
output [0:0] LEDR);
wire c1, c2, c3;
wire [0:3] h1,h2,h3;

delay_1_dec(CLOCK_50, c1);
timer #(10) (c1, KEY[0], 1'b1, h1, c2);
timer #(10) (c2, KEY[0], 1'b1, h2, c3);
timer #(10) (c3, KEY[0], 1'b1, h3, LEDR[0]);

decoder(h1, HEX0);
decoder(h2, HEX1);
decoder(h3, HEX2);

endmodule

module delay_1_dec(input clk, output Q);
	wire [0:25] A;
	wire e;
	counter_mod_m #(2) (clk, 1'b1, 1'b1, A);
	assign e=~|A;
	counter_mod_m #(2) (clk, 1'b1, e, Q);

endmodule

module counter_mod_m #(parameter M=10)
(input clk,aclr ,enable , output reg [0:N-1] Q);

localparam N=clogb2(M-1);
function integer clogb2(input [31:0] v);
		for (clogb2 = 0; v > 0; clogb2 = clogb2 + 1)
		v = v >> 1;
	endfunction
	
always@(posedge clk, negedge aclr)
	begin
		if(!aclr)			Q<={N{1'b0}};
		else if(Q==M-1)	Q<={N{1'b0}};
		else if(enable)	Q<= Q+1'b1;
		else					Q<= Q;
		
	end
	
endmodule

module timer #(parameter M=20)
(input clk,aclr  , enable, output reg [0:N-1] Q, output reg rollover);

localparam N=clogb2(M-1);
function integer clogb2(input [31:0] v);
		for (clogb2 = 0; v > 0; clogb2 = clogb2 + 1)
		v = v >> 1;
	endfunction

	always@(posedge clk, negedge aclr)
	begin
		if(!aclr)			Q<={N{1'b0}};
		else if(Q==M-1)	Q<={N{1'b0}};
		else if(enable)	Q<= Q+1'b1;
		else					Q<= Q;
		
	end
	
	always@(*)
	begin
		if(Q==M-1) rollover=1'b0;
		else 		  rollover=1'b1;
	end

endmodule

module decoder(input[0:3] x, output reg[0:6] h, output reg E);
 assign LEDR=x;

 always @(*)
 if(x>4'b1001) 
	 begin 
	 E=1;
	 end
 else
	 begin
	 E=0;
      	case(x)
            	4'd0: h=7'b0000001; 
            	4'd1: h=7'b1001111; 
            	4'd2: h=7'b0010010; 
            	4'd3: h=7'b0000110; 
            	4'd4: h=7'b1001100; 
            	4'd5: h=7'b0100100; 
            	4'd6: h=7'b0100000; 
            	4'd7: h=7'b0001111; 
            	4'd8: h=7'b0000000; 
            	4'd9: h=7'b0000100; 
 	       	default: h=7'b1111111;
      	endcase
			
end
endmodule
