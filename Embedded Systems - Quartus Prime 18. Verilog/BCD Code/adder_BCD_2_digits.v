module adder_BCD_2_digits(SW,LEDR, HEX0, HEX1,HEX3, HEX5);

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

module adder_BCD(input [0:3] x,y,input cin, output reg [0:6] hx, hy, s0, s1, output reg err);

wire z;
wire [0:3] A;
reg [0:4] m;

always @(*)
 	begin
      	decoder_hex_10(x[0:3], hx[0:6]);
      	decoder_hex_10(y[0:3], hy[0:6]);
      	
      	if(hx != 7'b1111111 && hy != 7'b1111111)
            	begin
            	
            	 m = x + y + cin;
            	comparator(m[0:4], z);
            	circut_a(m[0:4], A[0:3]);
            	decoder_hex_10(z, s1[0:6]);
            	if(z == 0)
      	       	decoder_hex_10(m[0:4], s0[0:6]);
            	else
                 	decoder_hex_10(A[0:3], s0[0:6]);
						
					err <= 0;
            	end
      	else
            	begin
            	
            	s0 = 7'b1111111;
            	s1 = 7'b1111111;
					err <= 1;
            	end
 	end
 	
 	task decoder_hex_10(
      	input x,
      	output h);
      	
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
	
 	task comparator(input a, output reg z);
      	
      	if(a > 4'd9)
            	z <= 1;
      	else
            	z <= 0;
 	endtask
 	
 	task circut_a(input in, output reg a);
      	
      	if(in > 5'd9)
            	a <= 4'd0;
      	else
            	a <= in - 5'd10;
      	
 	endtask
 	
 	

endmodule