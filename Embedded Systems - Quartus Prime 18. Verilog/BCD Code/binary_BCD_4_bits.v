module binary_BCD_4_bits(SW, HEX0, HEX1);

input [0:3]SW;
output [0:6] HEX0;
output [0:6] HEX1;

wire z;
wire [0:3] A;
wire [0:3] m;

comparator(SW[0:3], z);
circut_a(SW[0:3], A[0:3]);
mux_2_1_4(SW[0:3], A[0:3], z, m[0:3]);

decoder_hex_10(m[0:3], HEX0[0:6]);
decoder_hex_10_2(z, HEX1[0:6]);

endmodule


module circut_a(input [0:3]v, output [0:3]a);

	always @(*)
	if(v > 4'd9)
		case(x)
			4'd0: a = 4'b0000;
			4'd1: a = 4'b0001;
			4'd2: a = 4'b0010;
			4'd3: a = 4'b0011;
			4'd4: a = 4'b0100;
			4'd5: a = 4'b0101;
			default: a = 4'b0000;
		endcase
endmodule


module decoder_hex_10_2(input x, output reg [0:6] h);
	always @(*)
		case(x)
			1'd0: h = 7'b0000001;
			1'd1: h = 7'b1001111;
			1'd2: h = 7'b0010010;
			1'd3: h = 7'b0000110;
			1'd4: h = 7'b1001100;
			1'd5: h = 7'b0100100;
			default: h = 7'b1111111;
		endcase
endmodule


module decoder_hex_10(input [0:3]x, output reg [0:6] h);
	always @(*)
		case(x)
			4'd0: h = 7'b0000001;
			4'd1: h = 7'b1001111;
			4'd2: h = 7'b0010010;
			4'd3: h = 7'b0000110;
			4'd4: h = 7'b1001100;
			4'd5: h = 7'b0100100;
			4'd6: h = 7'b0100000;
			4'd7: h = 7'b0001111;
			4'd8: h = 7'b0000000;
			4'd9: h = 7'b0000100;
			default: h = 7'b1111111;
		endcase
endmodule


module comparator(input [0:3]v, output z);

always @(*)
	if(v > 4'd9)
		z <= 1;
	else 
		z <= 0;
endmodule


module mux_2_1_4(input [0:3]v, [0:3]A, s, output [0:3]out);

always @(*)
  if (s == 0)
    out <= v;
  else
    out <= A;

endmodule