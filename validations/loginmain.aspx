 <script language="javascript">
   
(function($) {

    $('#frmform').validate({
        rules : {
           '<%=ff_conferenceid.UniqueID%>' : {
                required: true
            },
            '<%=ff_email.UniqueID%>' : {
                email: true               
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