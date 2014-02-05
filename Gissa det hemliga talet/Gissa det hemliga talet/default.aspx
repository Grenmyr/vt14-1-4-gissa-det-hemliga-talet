<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gissa_det_hemliga_talet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server" defaultbutton="SubmitButton">
        <div>
            <%-- panel för styra presentation av det innanför panelen--%>
            <asp:Panel ID="SubmitPanel" runat="server" GroupingText="Ange tal mellan 1 - 100">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                <asp:PlaceHolder ID="SubmitPlaceHolder" runat="server">
                    <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="SubmitButton" runat="server" Text="Skicka" OnClick="SubmitButton_Click" />
                </asp:PlaceHolder>
                <asp:Label ID="Guess" runat="server"></asp:Label>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Label ID="PreviousGuesses" runat="server" ></asp:Label>
                </asp:Panel>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fyll i gissning" ControlToValidate="TextBox" Text="*"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1-100" ControlToValidate="TextBox" MaximumValue="100" MinimumValue="1" Type="Integer" Text="*"></asp:RangeValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Talet måste vara heltal" ControlToValidate="TextBox" Type="Integer" Operator="DataTypeCheck" Text="*"></asp:CompareValidator>
            </asp:Panel>
            <asp:Button ID="ResetButton" runat="server" Text="Starta om" Visible="false" OnClick="ResetButton_Click" />
        </div>
    </form>
</body>
</html>
