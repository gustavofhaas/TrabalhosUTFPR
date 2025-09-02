void main() {
  String primeiroNome = "Maria";
  String sobrenome = "Silva";

  print("Nome completo (concatenação): " + primeiroNome + " " + sobrenome);
  // A interpolação usa o cifrão ($) dentro de uma string com aspas duplas ("").
  // É a forma mais moderna e recomendada.
  print("Nome completo (interpolação): $primeiroNome $sobrenome");
}