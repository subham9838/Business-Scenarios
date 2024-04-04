// JavaScript source code
function OnSelect(executionContext) {
    debugger;
    var formContext = executionContext.getFormContext();
    if (formContext.getAttribute("crb9e_term").getValue == "1 Instalment") {
        formContext.getControl("crb9e_installment2").setVisible(false);
        formContext.getControl("crb9e_installment3").setVisible(false);
        formContext.getControl("crb9e_installment4").setVisible(false);
        formContext.getControl("crb9e_installment5").setVisible(false);
        formContext.getControl("crb9e_installment6").setVisible(false);
    }
    else if (formContext.getAttribute("crb9e_term").getValue == "2 Instalment") {
        formContext.getControl("crb9e_installment3").setVisible(false);
        formContext.getControl("crb9e_installment4").setVisible(false);
        formContext.getControl("crb9e_installment5").setVisible(false);
        formContext.getControl("crb9e_installment6").setVisible(false);
    }
    else if (formContext.getAttribute("crb9e_term").getValue == "3 Instalment") {
        formContext.getControl("crb9e_installment4").setVisible(false);
        formContext.getControl("crb9e_installment5").setVisible(false);
        formContext.getControl("crb9e_installment6").setVisible(false);
    }
    else if (formContext.getAttribute("crb9e_term").getValue == "4 Instalment") {
        formContext.getControl("crb9e_installment5").setVisible(false);
        formContext.getControl("crb9e_installment6").setVisible(false);
    }
    else if (formContext.getAttribute("crb9e_term").getValue == "5 Instalment") {
        formContext.getControl("crb9e_installment6").setVisible(false);
    }
}