using System;
using System.Collections;

class PilhaVaziaException : Exception {

}

class PilhaDuasFilas {
    int t = -1, capacidade = 1;
    object topo;
    object[] fila1 = new object[1];
    object[] fila2 = new object[1];

    public void dobrar() {
       object[] novaFila1 = new object[capacidade*2];
       object[] novaFila2 = new object[capacidade*2];

       for (int i = 0; i < tamanho(); i++) {
            novaFila1[i] = fila1[i];
            novaFila2[i] = fila2[i];
       }

       fila1 = novaFila1;
       fila2 = novaFila2;
       capacidade *= 2;
    }

    public int tamanho () {
        return t+1;
    }

    public bool pilhaVazia () {
        if (t == -1) return true;
        return false;
    }

    public void push (object o) {
        if (tamanho() == capacidade) {
            dobrar();
        }
        t++;
        fila1[t] = o;
        topo = o;
    }

    public object pop () {
        if (pilhaVazia()) {
            throw new PilhaVaziaException();
        }
        
        for (int i = 1; i < tamanho(); i++) {
            fila2[i-1] = fila1[i];
        }
        t--;
        object o = fila1[0];
        fila1 = fila2;
        fila2 = fila1;
        return o;
    }

    public object top () {
        return topo;
    }
}

class Teste {
    public static void Main () {
        PilhaDuasFilas p = new PilhaDuasFilas();
        p.push(1);
        p.push(2);
        p.push(3);
        p.push(4);
        p.push(5);
        p.push(6);
        Console.WriteLine(p.pop());
        Console.WriteLine(p.top());
    }
}
