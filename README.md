# Popis funkčnosti mé spirály

## Směrový systém
používám enumerace směrů, abych přesně viděl, jak se spirála bude orientovat, podle zadaného směru, kterým se má zrovna kreslit (R -> D -> L -> U). S tím se zárověň nese pár konfiktuů, jako je například nesprávné počítání mezer.

## Výhoda použití rekurze
- Spirála jakožto tvar je přirozeně rekurzivní, proto dodává k čitelnosti kódu - i přes to si myslím, že můj původní kód nebyl úplně špatně čitelný
- Podmínka ukončení rekurze je přímo v metodě a normálně se provádí, jakmile dosáhne středu spirály.

## Nevýhoda použití rekurze
- Sledování přesných vykreslování může být problém pro jakoukoliv specifickou úpravu kódu, která má být pořád stejná.
