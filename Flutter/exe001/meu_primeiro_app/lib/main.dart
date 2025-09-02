import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class Aluno {
  final String nome;
  final double nota;

  Aluno(this.nome, this.nota);
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Filtro de Alunos',
      theme: ThemeData(primarySwatch: Colors.blue),
      home: const FiltroAlunosPage(),
    );
  }
}

class FiltroAlunosPage extends StatefulWidget {
  const FiltroAlunosPage({super.key});

  @override
  State<FiltroAlunosPage> createState() => _FiltroAlunosPageState();
}

class _FiltroAlunosPageState extends State<FiltroAlunosPage> {
  final List<Aluno> alunos = [
    Aluno("Ana", 8.5),
    Aluno("Bruno", 6.0),
    Aluno("Carlos", 9.2),
    Aluno("Daniela", 7.3),
    Aluno("Eduardo", 5.8),
  ];

  double notaMinima = 0;

  @override
  Widget build(BuildContext context) {
    List<Aluno> filtrados =
        alunos.where((aluno) => aluno.nota >= notaMinima).toList();

    return Scaffold(
      appBar: AppBar(
        title: const Text("Filtro de Alunos"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            TextField(
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(
                labelText: "Nota mínima",
                border: OutlineInputBorder(),
              ),
              onChanged: (valor) {
                setState(() {
                  notaMinima = double.tryParse(valor) ?? 0;
                });
              },
            ),
            const SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: filtrados.length,
                itemBuilder: (context, index) {
                  final aluno = filtrados[index];
                  return ListTile(
                    title: Text(aluno.nome),
                    subtitle: Text("Nota: ${aluno.nota}"),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}
