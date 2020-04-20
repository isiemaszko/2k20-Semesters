module latch_D_gates(input [0:1] SW, output[0:0] LEDR);

latch_D(SW[1], SW[0], LEDR[0]);


endmodule

module latch_D(Clk,D, Q);

input Clk, D;
output Q;
wire R_g, S_g, Qa, Qb /* synthesis keep */ ;
nand(R_g, D, Clk);
nand(S_g, ~D, Clk);
nand(Qa, R_g, Qb);
nand(Qb, S_g, Qa);
assign Q=Qa;

endmodule