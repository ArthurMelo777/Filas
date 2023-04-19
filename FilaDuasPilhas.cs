// Colocar uma pilha como detentora dos elementos e a outra
// como controladora dos indices a serem retirados

using System;

class Pilha {
    private int t = -1;
    private object[] pilha = new object[1];

    public int tamanho () { 
        return t+1;
    }

    public bool pilhaVazia () {
        if (t == -1) return true;
        return false;
    }
}

class FilaDuasPilhas {
    
}