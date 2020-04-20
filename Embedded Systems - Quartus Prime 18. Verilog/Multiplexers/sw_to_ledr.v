module sw_to_ledr(SW, LEDR);
	input[9:0]SW; // przełączniki
	output [9:0] LEDR; // czerwoneLED
	assign LEDR = SW;
endmodule