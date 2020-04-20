module latch_master_slave_D(input [0:1] SW, output[0:0] LEDR);

wire Qm;

latch_D(~SW[1], SW[0], Qm);
latch_D(SW[1], Qm, LEDR[0]);


endmodule

module latch_D(Clk,D, Q)/* synthesis keep */ ;

input Clk, D;
output Q;
wire R_g, S_g, Qa, Qb;
nand(R_g, D, Clk);
nand(S_g, ~D, Clk);
nand(Qa, R_g, Qb);
nand(Qb, S_g, Qa);
assign Q=Qa;

endmodule
