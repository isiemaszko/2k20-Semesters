module mux_4_1_1 (SW, KEY, LEDR);

	input [0:3]SW;
	input [0:1]KEY;
	output [0:0]LEDR;
	
	wire[0:1]M;
	
	low_mux(SW[0], SW[1], KEY[0], M[0]);
	low_mux(SW[2], SW[3], KEY[0], M[1]);
	low_mux(M[0], M[1], KEY[1], LEDR[0]);

endmodule

//module mux0(input x, y, s, output m);
//	assign m = (~s & x) | (s & y);
//endmodule
//
//module mux1(input x, y, s, output m);
//	assign m = (~s & x) | (s & y);
//endmodule
//
//module mux2(input x, y, s, output m);
//	assign m = (~s & x) | (s & y);
//endmodule