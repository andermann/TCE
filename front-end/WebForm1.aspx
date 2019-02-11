<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="front_end.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link href="~/Content/GridTemplate.css" rel="stylesheet" />
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="scripts/jquery.blockUI.js"></script>
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({ message: '<div align = "center">' + '<img src="images/loadingAnim.gif"/></div>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    };
</script>

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Grid com dados.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

<div id="dvGrid" style="padding: 10px; width: 450px">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                DataKeyNames="ISBN" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize = "3" AllowPaging ="true" OnPageIndexChanging = "OnPaging"
                OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                Width="450">
                <Columns>
                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNome" runat="server" Text='<%# Eval("Nome") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Autor" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblAutor" runat="server" Text='<%# Eval("Autor") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAutor" runat="server" Text='<%# Eval("Autor") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Preco" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPreco" runat="server" Text='<%# Eval("Preco") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPreco" runat="server" Text='<%# Eval("Preco") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DataPublicacao" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblDataPublicacao" runat="server" Text='<%# Eval("DataPublicacao") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDataPublicacao" runat="server" Text='<%# Eval("DataPublicacao") %>' Width="140"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                        ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                <tr>
                    <td style="width: 150px">
                        <asp:TextBox ID="txtISBN" runat="server" Width="25" />
                        Nome:<br />
                        <asp:TextBox ID="txtNome" runat="server" Width="140" />
                    </td>
                    <td style="width: 150px">
                        Autor:<br />
                        <asp:TextBox ID="txtAutor" runat="server" Width="140" />
                    </td>
                    <td style="width: 150px">
                        Preco:<br />
                        <asp:TextBox ID="txtPreco" runat="server" Width="140" />
                    </td>
                    <td style="width: 150px">
                        DataPublicacao:<br />
                        <asp:TextBox ID="txtDataPublicacao" runat="server" Width="140" />
                    </td>
                    <td style="width: 150px">
                        <asp:Button ID="btnAdd" runat="server" Text="Incluir" OnClick="Insert" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
    

</asp:Content>
