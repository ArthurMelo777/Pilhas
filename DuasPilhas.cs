using System;

public class EPilhaVermelhaVazia : Exception {
    
}

public class EPilhaPretaVazia : Exception {
    
}

class PilhaRubroNegra {
    // Atributos da classe
    private int tamanho = 10;
    private object[] vetor = new object[10];
    private int tVermelha = -1, tPreta = 10;

    // Metodos Pilha Rubro Negra
    public void Dobrar () {
        this.tamanho = this.tamanho*2;
        object[] novoVetor = new object[this.tamanho];
        int i;

        // Iteração para duplicação da pilha vermelha
        for (i = 0; i < this.tamanhoVermelha(); i++) {
            novoVetor[i] = vetor[i];
        }

        // Iteração para duplicação da pilha preta
        int j = this.tamanhoVermelha();
        for (i = this.tamanho - this.tamanhoPreta(); i < this.tamanho; i++) {
            novoVetor[i] = vetor[j];
            j++;
        }
        this.tPreta = this.tamanho - this.tamanhoPreta();

        vetor = novoVetor;
    }

    // Metodos Pilha Vermelha
    public int tamanhoVermelha () {
        return tVermelha+1;
    }
    public void PushVermelho (object o) {
        if (this.tamanhoVermelha() + this.tamanhoPreta() == tamanho) {
            this.Dobrar();
        }

        tVermelha++;
        vetor[tVermelha] = o;
    }

    public object PopVermelho () {
        if (tVermelha == -1) {
            throw new EPilhaVazia();
        }
        else {
            object elemento = vetor[tVermelha];
            tVermelha--;
            return elemento;
        }
    }

    public object TopVermelho () {
        if (tVermelha == -1) {
            throw new EPilhaVermelhaVazia();
        }
        else {
            return vetor[tVermelha];
        }
    }

    // Metodos Pilha Preta
    public int tamanhoPreta () {
        return this.tamanho-tPreta;
    }

    public void PushPreto (object o) {
        if (this.tamanhoVermelha() + this.tamanhoPreta() == tamanho) {
            this.Dobrar();
        }

        tPreta--;
        vetor[tPreta] = o;
    }

    public object PopPreto () {
        if (tPreta == this.tamanho) {
            throw new EPilhaPretaVazia();
        }
        else {
            object elemento = vetor[tPreta];
            tPreta++;
            return elemento;
        }
    }

    public object TopPreto () {
        if (tPreta == this.tamanho) {
            throw new EPilhaPretaVazia();
        }
        else {
            return vetor[tPreta];
        }
    }
    
    public void exibirPilha () {
        for (int i = 0; i < tamanho; i++) {
            Console.Write($"[{vetor[i]}] ");
        }
    }
}

class Programa {

    public static void Main (string[] args) {
        PilhaRubroNegra p = new PilhaRubroNegra();
        p.PushVermelho(5);
        p.PushPreto(6);
        p.PushVermelho(4);
        p.PushPreto(7);
        p.PushVermelho(3);
        p.PushPreto(8);
        p.PushVermelho(2);
        p.PushPreto(9);
        p.PushVermelho(1);
        p.PushPreto(10);
        p.exibirPilha();
        Console.WriteLine();
        Console.WriteLine(p.PopPreto());
        Console.WriteLine(p.PopVermelho());
        Console.WriteLine(p.TopPreto());
        Console.WriteLine(p.TopVermelho());
        p.exibirPilha();
    }
}