using System;

class FilaVaziaException : Exception {

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

class ListaLigadaFila {
    private int tam;
    private No primeiro, ultimo;
    public ListaLigadaFila () {
        primeiro = null;
        tam = 0;
    }

    public int tamanho () {
        return tam;
    }

    public bool filaVazia () {
        if (primeiro == null) return true;
        return false;
    }

    public void enfileirar (object e) {
        No novoNo = new No(e, null);
        
        if (primeiro == null) {
            primeiro = novoNo;
        }
        else {
            ultimo.setNext(novoNo);
        }

        ultimo = novoNo;
        tam++;
    }

    public object desfileirar () {
        if (tam == 0) {
            throw new FilaVaziaException();
        }
        object e = primeiro.getElemento();
        primeiro = primeiro.getNext();
        tam--;
        if (tam == 0) ultimo = null;
        return e;
    }

    public void exibirFila () {
        No aux = primeiro;
        for (int i = 0; i < tam; i++) {
            Console.Write($"[{aux.getElemento()}] ");
            aux = aux.getNext();
        }
        Console.WriteLine();
    }
}

class Teste {
    public static void Main (string[] args) {
        ListaLigadaFila f = new ListaLigadaFila();
        f.enfileirar(1);
        f.enfileirar(2);
        f.enfileirar(3);
        f.enfileirar(4);
        f.enfileirar(5);
        f.enfileirar(6);
        f.exibirFila();
        Console.WriteLine(f.desfileirar());
        Console.WriteLine(f.desfileirar());
        Console.WriteLine(f.desfileirar());
        Console.WriteLine(f.desfileirar());
        f.exibirFila();
    }
}