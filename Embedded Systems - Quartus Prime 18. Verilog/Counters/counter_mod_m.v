module counter_mod_m(
	input CLOCK_50,
	input [1:0]SW,
	output [0:6]HEX0);
	
	counter(CLOCK_50, SW[1], SW[0], HEX0);
endmodule

module counter(input clk, aclr, enable,
output [0:6] h);

	localparam As=clogb2(50000000);
		function integer clogb2(input [31:0] v);
		for (clogb2 = 0; v > 0; clogb2 = clogb2 + 1)
		v = v >> 1;
	endfunction
	
	wire [As-1:0] A;
	wire sec;
	wire [3:0] B;
	counter_m #(50000000) (clk,aclr, enable, A);
	assign sec=~A;
	counter_m #(9) (clk, aclr, sec, B);
	
	decoder(B, h);
endmodule

module counter_m #(parameter M=10)
(input clk, aclr, enable, output reg [0:N-1] Q);

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


//
//module counter(input clk, aclr, enable,
//output [0:6] h);
//
//	localparam N=clogb2(50000000-1);
//	localparam N1=clogb2(10-1);
//	function integer clogb2(input [31:0] v);
//		for (clogb2 = 0; v > 0; clogb2 = clogb2 + 1)
//		v = v >> 1;
//	endfunction
//	
//	wire [0:N-1] A;
//	wire [0:3] B;
//	wire sek;
//	
//	counter_m #(N,50000000)(clk, ~aclr, enable, A);
//	assign sek=~|A;
//	counter_m #(N1,10)(clk, ~aclr, sek, B);
//	
//	decoder(B, h);
//	
//endmodule 
//
//module counter_m #(N,M)
//(input clk, aclr, enable, output reg [0:N-1] q);
//
//always@(posedge clk, negedge aclr)
//	begin
//		if(!aclr)			q<={N{1'b0}};
//		else if(enable)	q<= (q + 1) % M;
//		else					q<= q;
//		
//	end
//	
//endmodule
//
module decoder(
 	input[3:0] x, output reg[6:0] h);
 	always @(*)
 	begin
      	case(x)
            	4'b0000: h=7'b0000001; //0
            	4'b0001: h=7'b1001111; //1
            	4'b0010: h=7'b0010010; //2
            	4'b0011: h=7'b0000110; //3
            	4'b0100: h=7'b1001100; //4
            	4'b0101: h=7'b0100100; //5
            	4'b0110: h=7'b0100000; //6
            	4'b0111: h=7'b0001111; //7
            	4'b1000: h=7'b0000000; //8
            	4'b1001: h=7'b0000100; //9
            	4'b1010: h=7'b0001000; //10 a
            	4'b1011: h=7'b1100000; //11 b
            	4'b1100: h=7'b0110001; //12 c
            	4'b1101: h=7'b1000010; //13 d
            	4'b1110: h=7'b0110000; //14 e
            	4'b1111: h=7'b0111000; //15 f
 	       	default: h=7'b1111111;
      	endcase
 	end
endmodule


//module 
//	
//	localparam M1=50000000;
//	localparam M2=10;
//	localparam N1=clogb2(M1-1);
//	localparam N2=clogb2(M2-1);
//	function integer clogb2(input [31:0] v);
//		for (clogb2 = 0; v > 0; clogb2 = clogb2 + 1)
//		v = v >> 1;
//	endfunction
//
//	wire [N2-1: 0]q;
//	wire [N1-1: 0]e;
//	wire en;
//	
//	ps5 #(M1, N1) counter_1_s(CLOCK_50, ~SW[0], SW[1], e);
//	
//	assign en = ~|e;
//	
//	ps5 #(M2, N2) counter_mod(CLOCK_50, ~SW[0], en, q);
//
//	decoder_hex_16 h0(q[3:0], HEX0);
//endmodule
//
//

//
//
//module ps5 #(M, N)(
//	input clk,
//	input areset,
//	input enable,
//	output reg [N-1:0]q);
//	
//	always@(posedge clk, negedge areset)
//	begin
//		if(!areset)			q<={N{1'b0}};
//		else if(enable)	q<= (q + 1) % M;
//		else					q<= q;
//		
//	end
//	
//endmodule


