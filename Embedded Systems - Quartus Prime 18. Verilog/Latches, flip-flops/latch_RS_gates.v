//module latch_RS_gates (Clk, R, S, Q);
//input Clk, R, S;
//output Q;
//
//wire R_g, S_g, Qa, Qb, KEEP="TRUE";
//and (R_g, R, Clk);
//and (S_g, S, Clk);
//nor (Qa, R_g, Qb);
//nor (Qb, S_g, Qa);
//assign Q = Qa;
//
//endmodule

module latch_RS_gates(
input [0:2] SW,output[0:0]LEDR);

RS_gates(SW[2], SW[1], SW[0], LEDR[0]);

endmodule

module RS_gates(Clk, R, S, Q);
	input Clk, R,S;
	output Q;
	
	wire R_g, S_g, Qa, Qb /* synthesis keep */  ;
	and (R_g, R, Clk);
	and (S_g, S, Clk);
	nor (Qa, R_g, Qb);
	nor (Qb, S_g, Qa);
	assign Q = Qa;
endmodule