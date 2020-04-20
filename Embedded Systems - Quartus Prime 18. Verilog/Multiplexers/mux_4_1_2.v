module mux_4_1_2(SW, KEY, LEDR);

	input[0:7]SW;
	input [0:1]KEY;
	output[0:1]LEDR;
	
	wire[0:3]A;
	assign A[0] = SW[1];
	assign A[1] = SW[3];
	assign A[2] = SW[5];
	assign A[3] = SW[7];
	
	wire[0:3]B;
	assign B[0] = SW[0];
	assign B[1] = SW[2];
	assign B[2] = SW[4];
	assign B[3] = SW[6];
	
	mux_4_1_1(A[0:3], KEY[0:1], LEDR[0]);
	mux_4_1_1(B[0:3], KEY[0:1], LEDR[1]);

endmodule

//module mux_4_1_1_0 (input u, v, w, x, s0, s1, output m);
//
//	wire[0:1]M;
//	
//	mux0(u, v, s0, M[0]);
//	mux1(w, x, s0, M[1]);
//	mux2(M[0], M[1], s1, m);
//
//endmodule
//
//module mux_4_1_1_1 (input u, v, w, x, s0, s1, output m);
//
//	wire[0:1]M;
//	
//	mux0(u, v, s0, M[0]);
//	mux1(w, x, s0, M[1]);
//	mux2(M[0], M[1], s1, m);
//
//endmodule
//
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

