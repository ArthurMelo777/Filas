using System;

// Obs: Problema atual: ele dobra a capacidade da fila mesmo
// sem haver necessidade (vide teste atual na classe testar)


class FilaArray {
    int capacidade = 1;
    object[] fila = new object[1];
    int i = 0, f = 0;

    public void dobrar () {
        object[] novaFila = new object[capacidade*2];

        for (int i = 0; i < capacidade; i++) {
            novaFila[i] = fila[i];
        }

        capacidade = capacidade*2;
        fila = novaFila;
    }

    public int tamanho () {
        return (capacidade - i + f) % capacidade;
    }

    public bool filaVazia () {
        return (tamanho() == 0);
    }

    public void enfileirar (object o) {
        if (tamanho() == capacidade-1) {
            dobrar();
        }
        fila[f] = o;
        f = (f+1) % capacidade;
    }

    public object desfileirar () {
        if (filaVazia()) {
            throw new FilaVaziaException();
        }
        object o = fila[i];
        fila[i] = null;
        i = (i+1) % capacidade;
        return o;
    }

    public void exibirFila() {
        foreach (object elemento in fila) {
            Console.WriteLine($"[{elemento}]");
        }
        Console.WriteLine();
    }
}

class Testar {
    public static void Main () {
        FilaArray f = new FilaArray();
        f.enfileirar(1);
        f.enfileirar(2);
        f.enfileirar(3);
        f.enfileirar(4);
        f.enfileirar(5);
        f.enfileirar(6);
        f.exibirFila();
        Console.WriteLine(f.desfileirar());
        Console.WriteLine(f.desfileirar());
        f.exibirFila();
        f.enfileirar(7);
        f.enfileirar(8);
        f.enfileirar(9);
        f.enfileirar(10);
        f.exibirFila();
    }
}