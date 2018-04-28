$.validator.unobtrusive.adapters.addSingleVal("regraidademinima", "valoridademinima");

$.validator.addMethod("regraidademinima", function (value, element, valoridademinima)
{
    return  value && 
            Date.parseExact(value, "dd/mm/yyyy") &&
            Date.parseExact(value, "dd/mm/yyyy").addYears(valoridademinima) <= Date.today();
});