using System;

class FilaVaziaException : Exception {
    
}

class FilaDuasPilhas {
    int inicio = 0, fim = 0;
    int tam = 0, capacidade = 1;
    object[] pilha1 = new object[100];
    object[] pilha2 = new object[100];

    public void dobrar () {
        object[] novaPilha1 = new object[capacidade*2];
        object[] novaPilha2 = new object[capacidade*2];

        int j = tam-1;
        for (int i = 0; i < tam; i++) {
            pilha2[i] = pilha1[j];
            j--;
        }
        j = tam-1;
        for (int i = 0; i < tam; i++) {
            novaPilha1[i] = pilha2[j];
            j--;
        }

        pilha1 = novaPilha1;
        pilha2 = novaPilha2;
        capacidade *= 2;
    }

    public int tamanho () {
        return tam;
    }

    public bool filaVazia () {
        if (inicio == fim) return true;
        return false;
    }

    public bool pilhaVazia (object[] p) {
        if (p[0] == null) return true;
        return false;
    }

    public void enfileirar (object o) {
        pilha1[tam] = o;
        fim++;
        tam++;
    }

    public object desenfileirar () {
        if (filaVazia()) {
            throw new FilaVaziaException();
        }
        object o = null;
        if (pilhaVazia(pilha2)) {
            int j = tam-1;
            for (int i = 0; i < tam; i++) {
                pilha2[i] = pilha1[j];
                j--;
            }
            o = pilha2[tam-1];
            tam--;
            inicio--;
        }

        object[] aux = pilha1;
        pilha1 = pilha2;
        pilha2 = aux;
        pilha2[0] = null;
        return o;
    }
}

class Teste {
    public static void Main () {
        FilaDuasPilhas f = new FilaDuasPilhas();

        f.enfileirar(1);
        f.enfileirar(2);
        f.enfileirar(3);
        f.enfileirar(4);
        f.enfileirar(5);
        Console.WriteLine($"{f.desenfileirar()}");
        Console.WriteLine($"{f.desenfileirar()}");
    }
}
