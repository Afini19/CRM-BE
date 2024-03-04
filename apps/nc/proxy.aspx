<html>
<body>
<form name=frmForm method=Post action="<%=Request.QueryString("np")%>">
<Input type=hidden value="<%=Request.QueryString("uid")%>" name="caishuid">
</form>
<script language=Javascript>
	document.frmForm.submit();
</script>

</body>
</html>
