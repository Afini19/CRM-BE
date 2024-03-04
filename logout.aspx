<%

    Dim isadmin As Boolean = WebLib.UserIsFullAdmin

    WebLib.UserUID = ""
    WebLib.BranchID = ""
    WebLib.UserID = ""
    WebLib.UserCode = ""
    WebLib.UserName = ""
    WebLib.UserEmail = ""
    WebLib.MerchantID = ""
    WebLib.ActionParamMMUID = ""
    WebLib.UserIsFullAdmin = False
    
    Response.Redirect("loginmain.aspx")
 %>