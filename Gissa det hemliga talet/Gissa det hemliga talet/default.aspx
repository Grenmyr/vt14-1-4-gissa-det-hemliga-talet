<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gissa_det_hemliga_talet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Ange tal mellan 1 - 100">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                <asp:TextBox ID="TextBox" runat="server" ></asp:TextBox>
                <asp:Button ID="SubmitButton" runat="server" Text="Skicka" OnClick="SubmitButton_Click" />
                <asp:Label ID="Guesses" runat="server" Text="Make your guesses"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fyll i gissning" ControlToValidate="TextBox"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1-100" ControlToValidate="TextBox" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Talet måste vara heltal" ControlToValidate="TextBox" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </asp:Panel>
            <asp:Button ID="ResetButton" runat="server" Text="Starta om" Visible="false" />
        </div>
    </form>
</body>
</html>
