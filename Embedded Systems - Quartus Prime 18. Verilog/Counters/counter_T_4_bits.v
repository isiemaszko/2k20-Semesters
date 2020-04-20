//module counter_T_4_bits(
//input [1:0] SW, input[0:0] KEY,
//output [0:6] HEX0);
//
//wire [0:3] x;
//
//counter(KEY[0], SW[0], SW[1], x);
//decoder(x, HEX0[0:6]);
//
//endmodule

//module counter_T_4_bits(
//SW, KEY, HEX0);
//
//input [0:1] SW;
//input [0:0] KEY;
//output [0:6] HEX0;
//
//wire q1,q2,q3,q4,t2,t3,t4;
//FFT_areset c1(KEY[0], ~SW[0], SW[1], q1);
//assign t2=q1&SW[1];
//FFT_areset c2(KEY[0], ~SW[0], t2,q2);
//assign t3=q2&t2;
//FFT_areset c3(KEY[0], ~SW[0], t3,q3);
//assign t4=q3&t3;
//FFT_areset c4(KEY[0], ~SW[0], t4,q4);
//
//decoder({q4,q3,q2,q1}, HEX0);
//
//endmodule
//
//
//
//module FFT_areset(
//input T, clk, aclr, 
//output reg Q);
//always @(posedge clk, negedge aclr)
//if(!aclr) Q<=1'b0;
//else if(T) Q<=~Q;
//else Q<=Q;
//
//endmodule
//
////module counter(
////input clk, aclr, enable, 
////output [0:3] Q);
////
////wire [1:3] C;
////
////assign C[1]=Q[0]&enable;
////assign C[2]=Q[1]&C[1];
////assign C[3]=Q[2]&C[2];
////
////FFT_areset ex0(enable, clk, aclr, Q[0]);
////FFT_areset ex1(C[1], clk, aclr, Q[1]);
////FFT_areset ex2(C[2], clk, aclr, Q[2]);
////FFT_areset ex3(C[3], clk, aclr, Q[3]);
////
////endmodule
//
//module decoder(
//input [0:3] x,
//output reg [0:6] h);
//always@(*)
//	case(x)
//			4'd0:
//					h = 7'b0000001;
//			4'd1: 
//					h = 7'b1001111;
//			4'd2: 
//					h = 7'b0010010;
//			4'd3: 
//					h = 7'b0000110;
//			4'd4: 
//					h = 7'b1001100;
//			4'd5: 
//					h = 7'b0100100;
//			4'd6: 
//					h = 7'b0100000;
//			4'd7: 
//					h = 7'b0001111;
//			4'd8: 
//					h = 7'b0000000;
//			4'd9: 
//					h = 7'b0000100;
//			4'd10: 
//					h = 7'b0001000;
//			4'd11: 
//					h = 7'b1100000;
//			4'd12: 
//					h = 7'b0110001;
//			4'd13: 
//					h = 7'b1000010;
//			4'd14: 
//					h = 7'b0110000;
//			4'd15: 
//					h = 7'b0111000;
//			default:
//						h = 7'b1111111;
//				
//		endcase
//endmodule		


module counter_T_4_bits(
	
	input [0:0]KEY,
	input [1:0]SW,
	output [0:6]HEX0);
	
	wire l1, l2, l3, l4, c2, c3, c4;

	
	FFT_areset ex0(KEY[0], ~SW[0], SW[1], l1);
	
	assign c2 = l1 & SW[1];
	
	FFT_areset ex1(KEY[0], ~SW[0], c2, l2);
	
	assign c3 = l2 & c2;
	FFT_areset ex2(KEY[0], ~SW[0], c3, l3);
	
	assign c4 = l3 & c3;
	FFT_areset ex3(KEY[0], ~SW[0], c4, l4);
	

	
	decoder h0({l4, l3, l2, l1}, HEX0);
	
endmodule


module FFT_areset(
input clk,
	input areset,
	input enable,
	output reg q);
	
	always@(posedge clk, negedge areset)
	begin
		if(!areset)			q<=1'b0;
		else if(enable)	q<= ~q;
		else					q<= q;
		
	end
endmodule

module decoder(
 	input[0:3] x, output reg[0:6] h);
 	always @(*)
 	begin
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
            	4'd10: h=7'b0001000; 
            	4'd11: h=7'b1100000; 
            	4'd12: h=7'b0110001; 
            	4'd13: h=7'b1000010; 
            	4'd14: h=7'b0110000; 
            	4'd15: h=7'b0111000; 
 	       	default: h=7'b1111111;
      	endcase
 	end
endmodule

//module counter_T_4_bits(SW, KEY, HEX0);
//input [0:1] SW;
//input [0:0] KEY;
//output [0:6] HEX0;
//
//counter_T(SW[0], SW[1], KEY[0], HEX0[0:6]);
//
//
//endmodule
//
//module counter_T(
//	input [0:0]areset, input [0:0]enable, input [0:0]clk, output[0:6] Q);
//	
//	wire l1, l2, l3, l4;
//	wire c2, c3, c4;
//
//	
//	FFT_areset ex0(clk, ~areset,enable, l1);
//	
//	assign c2 = l1 & enable;
//	
//	FFT_areset ex1(clk, ~areset, c2, l2);
//	
//	assign c3 = l2 & c2;
//	FFT_areset ex2(clk, ~areset, c3, l3);
//	
//	assign c4 = l3 & c3;
//	FFT_areset ex3(clk, ~areset, c4, l4);
//	
//
//	
//	decoder({l4, l3, l2, l1}, h);
//	
//endmodule
//
//
//module FFT_areset(
//input T, clk, aclr, 
//output reg Q);
//
//always @(posedge clk, negedge aclr)
//if(!aclr) Q<=1'b0;
//else if(T) Q<=~Q;
//else Q<=Q;
//
//endmodule
//
//module decoder(
// 	input[0:3] x, output reg[0:6] h);
// 	always @(*)
//      	case(x)
//            	4'd0: h=7'b0000001; 
//            	4'd1: h=7'b1001111; 
//            	4'd2: h=7'b0010010; 
//            	4'd3: h=7'b0000110; 
//            	4'd4: h=7'b1001100; 
//            	4'd5: h=7'b0100100; 
//            	4'd6: h=7'b0100000; 
//            	4'd7: h=7'b0001111; 
//            	4'd8: h=7'b0000000; 
//            	4'd9: h=7'b0000100; 
//            	4'd10: h=7'b0001000; 
//            	4'd11: h=7'b1100000; 
//            	4'd12: h=7'b0110001; 
//            	4'd13: h=7'b1000010; 
//            	4'd14: h=7'b0110000; 
//            	4'd15: h=7'b0111000; 
// 	       	default: h=7'b1111111;
//      	endcase
//endmodule


 