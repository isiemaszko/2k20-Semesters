module control_timer(
input CLOCK_50, output [0:7]LEDR);

control_LEDR #(2) (CLOCK_50, LEDR[0]);
control_LEDR #(5) (CLOCK_50, LEDR[1]);
control_LEDR #(10) (CLOCK_50, LEDR[2]);
control_LEDR #(16) (CLOCK_50, LEDR[3]);
control_LEDR #(24) (CLOCK_50, LEDR[4]);
control_LEDR #(30) (CLOCK_50, LEDR[5]);
control_LEDR #(36) (CLOCK_50, LEDR[6]);
control_LEDR #(40) (CLOCK_50, LEDR[7]);

endmodule

module control_LEDR #(parameter M=10)
(input clk, output reg [0:0] ledr);

localparam N=ceillog2(M-1);
function integer ceillog2(input [31:0] v);
		for (ceillog2 = 0; v > 0; ceillog2 = ceillog2 + 1)
		v = v >> 1;
	endfunction
	
reg [0:N-1] A;
	always @(posedge clk)
		if(A==M-1)
			begin 
				A<={N{1'b0}};
				ledr=~ledr;
			end
		else
			A<=A+1;
	
endmodule
