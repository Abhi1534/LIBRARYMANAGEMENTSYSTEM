<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembershippaymentInitiation.aspx.cs" Inherits="LIBRARYMANAGEMENTSYSTEM.MembershippaymentInitiation" %>

<!DOCTYPE html>
<html>
   <head>
      <title>Show Payment Page</title>
   </head>
   <body>
      <center>
         <h1>Please do not refresh this page...</h1>
      </center>
     <%--  https://securegw-stage.paytm.in/theia/api/v1/showPaymentPage?mid=TELANG38998201047460&orderId=YOUR_ORDERID_HERE--%>
      <form method="post" runat="server" id="frmLink" name="paytm">
         <table border="1">
            <tbody>
               <input type="hidden" runat="server" id="mid" name="mid">
               <input type="hidden" runat="server" id="orderId" name="orderId">
               <input type="hidden" name="txnToken" id="txnToken" runat="server">
            </tbody>
         </table>
         <script type="text/javascript"> document.paytm.submit(); </script>
      </form>
       <table align='center'>
			<tr>
				<td><STRONG>Transaction is being processed,</STRONG></td>
			</tr>
			<tr>
				<td><font color='blue'>Please wait ...</font></td>
			</tr>
			<tr>
				<td>(Please do not press 'Refresh' or 'Back' button</td>
			</tr>
		</table>
		<FORM NAME='TESTFORM' action="admin/PaymentConformation.aspx"  METHOD='POST'>
			<input type='hidden' name='CURRENCY' value='PAYMENT_CURRENCY'>
			<input type='hidden' name='GATEWAYNAME' value='GATEWAY_USED_BY_PAYTM'>
			<input type='hidden' name='RESPMSG' value='PAYTM_RESPONSE_MESSAGE_DESCRIPTION'>
			<input type='hidden' name='BANKNAME' value='BANK_NAME_OF_ISSUING_PAYMENT_MODE'>
			<input type='hidden' name='PAYMENTMODE' value='PAYMENT_MODE_USED_BY_CUSTOMER'>
			<input type='hidden' name='MID' value='YOUR_MID_HERE'>
			<input type='hidden' name='RESPCODE' value='PAYTM_RESPONSE_CODE'>
			<input type='hidden' name='TXNID' value='PAYTM_TRANSACTION_ID'>
			<input type='hidden' name='TXNAMOUNT' value='ORDER_TRANSACTION_AMOUNT'>
			<input type='hidden' name='ORDERID' value='YOUR_ORDER_ID'>
			<input type='hidden' name='STATUS' value='PAYTM_TRANSACTION_STATUS'>
			<input type='hidden' name='BANKTXNID' value='BANK_TRANSACTION_ID'>
			<input type='hidden' name='TXNDATE' value='TRANSACTION_DATE_TIME'>
			<input type='hidden' name='CHECKSUMHASH' value='PAYTM_GENERATED_CHECKSUM_VALUE'>
		</FORM>
	
	<script type="text/javascript">  document.forms[0].submit();</script>    
   </body>
</html>

		
