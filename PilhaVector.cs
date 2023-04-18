using System;
using System.Collections;

class pilhaVaziaException : Exception {

}

public interface IPilhaVec {
    int size () ;
    void push (object o) ;
    object pop () ;
    object top () ;
}

public class PilhaVec : IPilhaVec{
    int t = -1;
    int n = 0;
    ArrayList stack = new ArrayList();

    public int size () {
        return t+1;
    }

    public void push (object o) {
        stack.Add(o);
        t++;
    }

    public object pop () {
        if (size() == 0) { throw new pilhaVaziaException();}
        object obj = stack[t];
        stack.RemoveAt(t);
        t--;
        return obj;
    }

    public object top () {
        if (size() == 0) { throw new pilhaVaziaException();}
        return stack[t];
    }

    public void exibirPilha () {
        if (size() == 0) { throw new pilhaVaziaException();}
        for (int i = t; i > -1; i--) {
            Console.WriteLine($"[{stack[i]}]");
        }
    }
}

class Teste {
    public static void Main () {
        PilhaVec p = new PilhaVec ();
        p.push(1);
        p.push(2);
        p.push(3);
        p.push(4);
        p.push(5);
        p.push(6);
        p.exibirPilha();
        Console.WriteLine($"O pop retornou {p.pop()}");
        Console.WriteLine($"O top retornou {p.top()}");
        p.exibirPilha();
    }
}