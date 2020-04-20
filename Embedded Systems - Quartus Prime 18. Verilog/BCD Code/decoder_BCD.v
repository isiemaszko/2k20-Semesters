module decoder_BCD(SW, LEDR, HEX0, HEX1);

	input [0:7]SW;
	output [0:9]LEDR;
	output [0:6]HEX0;
	output [0:6]HEX1;
	
	//decoder_hex_10(SW[0], SW[1], SW[2], SW[3], HEX0[0], HEX0[1], HEX0[2], HEX0[3], HEX0[4], HEX0[5], HEX0[6]);
	decoder_hex_10(SW[0:3], HEX0[0:6], LEDR[0:3], LEDR[8]);
	decoder_hex_10(SW[4:7], HEX1[0:6], LEDR[4:7], LEDR[9]);
	
endmodule

module decoder_hex_10(input [0:3]x, output reg [0:6] h, output [0:3] out, output reg err);

	assign out = x;
	//err <= 1'b1;
	//err = 1;

	always @(*)
		case(x)
			4'd0:
				begin
					err = 1'b0;
					h = 7'b0000001;
				end
			4'd1: 
				begin
					err = 1'b0;
					h = 7'b1001111;
				end
			4'd2: 
				begin
					err = 1'b0;
					h = 7'b0010010;
				end
			4'd3: 
				begin
					err = 1'b0;
					h = 7'b0000110;
				end
			4'd4: 
				begin
					err = 1'b0;
					h = 7'b1001100;
				end
			4'd5: 
				begin
					err = 1'b0;
					h = 7'b0100100;
				end
			4'd6: 
				begin
					err = 1'b0;
					h = 7'b0100000;
				end
			4'd7: 
				begin
					err = 1'b0;
					h = 7'b0001111;
				end
			4'd8: 
				begin
					err = 1'b0;
					h = 7'b0000000;
				end
			4'd9: 
				begin
					err = 1'b0;
					h = 7'b0000100;
				end
			default:
					begin
						err = 1'b1;
						h = 7'b1111111;
					end
						
			
		endcase
endmodule