# 📊Receita Federal DataScraping
<h3>Atualmente ele só faz a consulta de cpf.</h3>

<p>Para conseguir bular o captcha da receita federal iremos utiliza a plataforma <a href="https://bestcaptchasolver.com/ref/5f879ce04f5ae85d80220feb">bestcaptchasolver</a>.
Esse site tem um token de acesso que é o suficiente para verificar o captcha.
</p>

<h3>Obs:</h3>

<p>A unica parte paga é a solução para resolver os captchas, que sai por um preço bem em conta, mais barato que qualquer solução para consultar dados de um CPF.</p>

<h3>Para Buscar pelo cpf e data de nascimento:</h3>
<p>O método ValidateCpfData retorna um dicionario contendo os dados ou uma mensagem de erro.</p>

<p>Esse método recebe 3 parametro que são: Cpf, Data de nascimento e o Token De Acesso do <a href="https://bestcaptchasolver.com/ref/5f879ce04f5ae85d80220feb">bestcaptchasolver</a> que podem ser passado de duas maneiras:</p>

```csharp
Dictionary<string,string> cpfData = receitaFederal.ValidateCpfData("00011122233","11223333","BAC21DFA5FE5DORIME608BED45F8D703");
```
<h4>Ou:</h4>

```csharp
Dictionary<string,string> cpfData = receitaFederal.ValidateCpfData("000.111.222-33","11/22/3333","BAC21DFA5AMENO5CA9608BED45F8D703");
```

<h3>Dependencias:</h3>

<a href="https://www.nuget.org/packages/Selenium.WebDriver/3.141.0">Selenium WebDriver 3.141.0</a>

<a href="https://www.nuget.org/packages/Selenium.Chrome.WebDriver/85.0.0">Selenium Chrome WebDriver 85.0.0</a>
