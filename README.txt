

Hudební interpreti a jimi vydaná alba - aplikace s WPF, Entity Framework a databází.

Umožňuje autory a jimi vydaná alba do DB přidávat, editovat a odstraňovat.

Program správně funguje (Nahled.png), pokud je nainstalována SQL Server Express 2019 LocalDB, která je jako jediná LocalDB součástí Visual Studia Community 2022 a v případě její absence ji lze doinstalovat např. v oddílech "Vývoj desktopových aplikací pomocí .NET" nebo "Ukládání a zpracování dat".

- při ukládání nového nebo editaci uloženého autora/alba kontroluje vyplnění polí, zadání roku povolí
  pouze číslice v počtu 4 ks, rozsah 1900 až aktuální rok, vydání alba ne starší než začátek interpreta atd.
