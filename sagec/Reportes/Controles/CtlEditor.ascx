<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CtlEditor.ascx.vb" Inherits="Controles.CtlEditor" %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#editor').jqxEditor({
                height: "400px",
                width: '800px'
            });
        });
    </script>    
    <textarea id="editor">    
    </textarea>
    