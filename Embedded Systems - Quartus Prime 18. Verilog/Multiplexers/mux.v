module mux(SW, KEY, LEDR);
	
	input [0:2]SW;
	input [0:0]KEY;
	output [0:0]LEDR;
	low_mux(SW[0], SW[1], KEY[0], LEDR[0]);
	
endmodule
	
module low_mux(input x, y, s, output m);
	assign m = (~s & x) | (s & y);
endmodule