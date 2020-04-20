module mux_4(SW, KEY, LEDR);

	input [0:7]SW;
	input [0:0]KEY;
	output[0:3]LEDR;
	
	low_mux(SW[0], SW[4], KEY[0], LEDR[0]);
	low_mux(SW[1], SW[5], KEY[0], LEDR[1]);
	low_mux(SW[2], SW[6], KEY[0], LEDR[2]);
	low_mux(SW[3], SW[7], KEY[0], LEDR[3]);

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
//
//module mux3(input x, y, s, output m);
//	assign m = (~s & x) | (s & y);
//endmodule