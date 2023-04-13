using System;

public class EPilhaVazia : Exception {
    
}

public class Pilha {
    // Variaveis da classe
    private object [] vetor = new object[5];
    private int t = -1;

    // Metodos
    public void Push (object o) {
        t++;
        vetor[t] = o;
    }

    public object Pop () {
        if (t == -1) {
            throw new EPilhaVazia();
        }
        else {
            object elemento = vetor[t];
            t--;
            return elemento;
        }
    }

    public object Top () {
        if (t == -1) {
            throw new EPilhaVazia();
        }
        else {
            return vetor[t];
        }
    }
}

public class Program {
    public static void main (string[] args) {
        Pilha pilha = new Pilha();

        pilha.Push(5);
        pilha.Push(4);
        pilha.Push(3);
        Console.WriteLine(pilha.Pop());
        Console.WriteLine(pilha.Top());
    }
}