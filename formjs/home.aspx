 <script language="javascript">
   
(function($) {

    $('#<%=birth_date.ClientID%>').datepicker({
        dateFormat: "dd-mm-yy",
        showOn: "both",
        buttonText : '<i class="zmdi zmdi-calendar-alt"></i>'
    });

    $('.add-info-link').on('click', function() {
        $('.add_info').toggle( "slow" );
    });
    
    $('#frmform').validate({
        rules : {
           '<%=first_name.UniqueID%>' : {
                required: true
            },        
            '<%=last_name.UniqueID%>' : {
                required: true
            },
            '<%=password.UniqueID%>' : {
                required: true
            },
            '<%=birth_date.UniqueID%>' : {
                required: true
            },
            '<%=re_password.UniqueID%>' : {
                required: true,
                equalTo:  '#<%=password.ClientID%>'
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