module adder_BCD_2_digits_b(SW,LEDR, HEX0, HEX1,HEX3, HEX5);

input [0:8]SW;
output [0:6]HEX0;
output [0:6]HEX1;
output [0:6]HEX3;
output [0:6]HEX5;
output [0:9]LEDR;

assign LEDR[0]=SW[0];
assign LEDR[1]=SW[1];
assign LEDR[2]=SW[2];
assign LEDR[3]=SW[3];
assign LEDR[4]=SW[4];
assign LEDR[5]=SW[5];
assign LEDR[6]=SW[6];
assign LEDR[7]=SW[7];
assign LEDR[8]=SW[8];

	adder_BCD(SW[4:7], SW[0:3], SW[8],HEX5[0:6], HEX3[0:6], HEX1[0:6], HEX0[0:6], LEDR[9]);
endmodule

module adder_BCD(input [0:3] x,y,input c0, output reg [0:6] hx, hy, s0, s1, output reg err);

reg [0:4]z1;
reg [0:4]z0;
reg c1;
reg [0:4] m;

always @(*)
 	begin
      	decoder_hex_10(x[0:3], hx[0:6]);
      	decoder_hex_10(y[0:3], hy[0:6]);
      	
      	if(hx != 7'b1111111 && hy != 7'b1111111)
            	begin
            	
            	 m = x + y + c0;
            	
            	if(m>5'b01001)
      	       	begin
						z0=5'b01010;
						c1<=1;
						end
            	else
                 begin
					  z0=5'b00000;
					  c1<=0;
					  end
					err <= 0;
            	
					
					z1=m-z0;
					decoder_hex_10(z1, s0);
					decoder_hex_10(c1, s1);
					end
			else
            	begin
					s0=7'b1111111;
					s1=7'b1111111;
					err <= 1;
            	end
			
 	end
 	
 	task decoder_hex_10(
      	input[0:3] x,
      	output reg [0:6] h);
      	
      	case(x)
            	4'd0: h=7'b0000001;
            	4'd1: h=7'b1001111;
            	4'd2: h=7'b0010010;
            	4'd3: h=7'b0000110;
            	4'd4: h=7'b1001100;
            	4'd5: h=7'b0100100;
            	4'd6: h=7'b0100000;
            	4'd7: h=7'b0001111;
            	4'd8: h=7'b0000000;
            	4'd9: h=7'b0000100;
            	default: h=7'b1111111;
      	endcase
 	endtask
	
 	

endmodule