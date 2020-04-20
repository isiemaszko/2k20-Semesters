//module latch_RS_boolean(
//Clk,R,S, Q);
//
//input Clk, R,S;
//output Q;
//
//wire R_g, S_g, Qa, Qb, ;
//assign R_g=R&Clk;
//assign S_g=S&Clk;
//assign Qa=~(R_g|Qb);
//assign Qb=~(S_g|Qa);
//assign Q=Qa;
//
//
//endmodule



module latch_RS_boolean(
input [0:2] SW,output[0:0]LEDR);

latch_RS(SW[2], SW[1], SW[0], LEDR[0]);

endmodule

module latch_RS(Clk, R, S, Q);
	input Clk, R,S;
	output Q;

	wire R_g, S_g, Qa, Qb  ;
	assign R_g=R&Clk;
	assign S_g=S&Clk;
	assign Qa=~(R_g|Qb);
	assign Qb=~(S_g|Qa);
	assign Q=Qa;

endmodule