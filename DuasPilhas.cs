using System;

public class EPilhaVermelhaVazia : Exception {
    
}

public class EPilhaPretaVazia : Exception {
    
}

class PilhaRubroNegra {
    // Atributos da classe
    private int tamanho = 1;
    private object[] vetor = new object[1];
    private int tVermelha = -1, tPreta = 1;

    // Metodos Pilha Rubro Negra;
    public void Dobrar () {
        object[] novoVetor = new object[tamanho*2];
        int i, j = 0;
        bool x = true;

        // Iteração para duplicação da pilha
        for (i = 0; i < tamanho; i++) {
            if (i > tVermelha && x) {
                j = tamanho + tPreta;
                x = false;
            }
            novoVetor[j] = vetor[i];
            j++;
        }
        
        tPreta += tamanho;

        tamanho = tamanho*2;
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
            throw new EPilhaVermelhaVazia();
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
    
    // Exibir pilha

    public void exibirPilha () {
        for (int i = 0; i < tamanho; i++) {
            Console.Write($"[{vetor[i]}] ");
        }
    }
}