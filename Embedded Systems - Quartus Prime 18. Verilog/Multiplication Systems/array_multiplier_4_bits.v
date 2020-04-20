module array_multiplier_4_bits(
	input [7:0] SW,
	output [0:6] HEX0, HEX2, HEX5, HEX4,
	output [7:0]LEDR);

	
	decoder_hex_16 in0(SW[7:4], HEX2);
	decoder_hex_16 in1(SW[3:0], HEX0);
	wire [7:0] out;
	ps7(SW[7:4], SW[3:0], out);
	
	assign LEDR = out;
	
	decoder_hex_16 s0(out[7:4], HEX5);
	decoder_hex_16 s1(out[3:0], HEX4);
	
	
endmodule

module decoder_hex_16(
 	input[3:0] x, output reg[6:0] h);
 	always @(*)
 	begin
      	case(x)
            	4'b0000: h=7'b0000001; //0
            	4'b0001: h=7'b1001111; //1
            	4'b0010: h=7'b0010010; //2
            	4'b0011: h=7'b0000110; //3
            	4'b0100: h=7'b1001100; //4
            	4'b0101: h=7'b0100100; //5
            	4'b0110: h=7'b0100000; //6
            	4'b0111: h=7'b0001111; //7
            	4'b1000: h=7'b0000000; //8
            	4'b1001: h=7'b0000100; //9
            	4'b1010: h=7'b0001000; //10 a
            	4'b1011: h=7'b1100000; //11 b
            	4'b1100: h=7'b0110001; //12 c
            	4'b1101: h=7'b1000010; //13 d
            	4'b1110: h=7'b0110000; //14 e
            	4'b1111: h=7'b0111000; //15 f
 	       	default: h=7'b1111111;
      	endcase
 	end
endmodule

module ps7(
	input [3:0] a, b,
	output [7:0] p);
	
	reg ab [0:3][0:3];
	
	integer i, j;
	always@(*)
	begin
		for(i = 0; i<4; i= i+1)
		begin
			for(j=0; j<4; j= j+1)
			begin
				ab[i][j] = a[i] & b[j];
			end
		end
	end
	
	wire c [0:11];
	wire s [0:11];
	adder_1_bit adder0(ab[1][0], ab[0][1], 1'b0, s[0], c[0]);
	adder_1_bit adder1(ab[2][0], ab[1][1], c[0], s[1], c[1]);
	adder_1_bit adder2(ab[3][0], ab[2][1], c[1], s[2], c[2]);
	adder_1_bit adder3(1'b0, ab[3][1], c[2], s[3], c[3]);
	adder_1_bit adder4(s[1], ab[0][2], 1'b0, s[4], c[4]);
	adder_1_bit adder5(s[2], ab[1][2], c[4], s[5], c[5]);
	adder_1_bit adder6(s[3], ab[2][2], c[5], s[6], c[6]);
	adder_1_bit adder7(c[3], ab[3][2], c[6], s[7], c[7]);
	adder_1_bit adder8(s[5], ab[0][3], 1'b0, s[8], c[8]);
	adder_1_bit adder9(s[6], ab[1][3], c[8], s[9], c[9]);
	adder_1_bit adder10(s[7], ab[2][3], c[9], s[10], c[10]);
	adder_1_bit adder11(c[7], ab[3][3], c[10], s[11], c[11]);
	
	assign p = {c[11], s[11], s[10], s[9], s[8], s[4], s[0], ab[0][0]};
	
endmodule

module adder_1_bit(
	input a,b,
	input cin,
	output s,
	output cout);
	assign cout = (a + b + cin) / 2;
	assign s = (a + b + cin ) % 2;
endmodule



