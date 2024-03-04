 <script language="javascript">
   
(function($) {

    $('#frmform').validate({
        rules : {
           '<%=nc_name.UniqueID%>' : {
                required: true
            },
            '<%=nc_company.UniqueID%>' : {
                required: true                
            },
            '<%=nc_email.UniqueID%>' : {
                email: true               
            },
          '<%=nc_mobileno.UniqueID%>' : {
                pattern:/^([+][\d]{2})([\d]{1,20})$/             
            }            
        },
        messages:{
           '<%=nc_mobileno.UniqueID%>':
          {
          pattern:""
          }
        },
        onfocusout: function(element) {
            $(element).valid(); 
        }
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "",
        remote: "",
        email: "",
        url: "",
        date: "",
        dateISO: "",
        number: "",
        digits: "",
        creditcard: "",
        equalTo: ""
    });
})(jQuery);
 </script>