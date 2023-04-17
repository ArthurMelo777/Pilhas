using System;

class PilhaVaziaException : Exception {

}

class No {
    private object elemento;
    private No next;

    public No (object e, No n) {
        elemento = e;
        next = n;
    }
    public object getElemento () {
        return elemento;
    }

    public No getNext () {
        return next;
    }

    public void setElemento (object e) {
        elemento = e;
    }

    public void setNext (No n) {
        next = n;
    }
}

class ListaLigadaPilha {
    private int tam;
    private No topo;

    public ListaLigadaPilha () {
        topo = null;
        tam = 0;
    }

    public int tamanho () {
        return tam;
    }

    public bool pilhaVazia () {
        if (tam == 0) return true;
        return false;
    }

    public void push (object e) {
        No novoNo = new No(e, topo);
        topo = novoNo;
        tam++;
    }

    public object top () {
        if (pilhaVazia()) {
            throw new PilhaVaziaException();
        }
        return topo.getElemento();
    }

    public object pop () {
        if (pilhaVazia()) {
            throw new PilhaVaziaException();
        }
        object e = topo.getElemento();
        topo = topo.getNext();
        tam--;
        return e;
    }

    public void exibirPilha () {
        No noTemp = topo;
        for (int i = 0; i < tam; i++) {
            Console.WriteLine($"[{noTemp.getElemento()}]");
            noTemp = noTemp.getNext();
        }
    }
}

class Teste {
    public static void Main (string[] args) {
        ListaLigadaPilha p = new ListaLigadaPilha();
        p.push('a');
        p.push('r');
        p.push('t');
        p.push('h');
        p.push('u');
        p.push('r');
        p.exibirPilha();
        Console.WriteLine(p.top());
        Console.WriteLine(p.pop());
        p.exibirPilha();
    }
}