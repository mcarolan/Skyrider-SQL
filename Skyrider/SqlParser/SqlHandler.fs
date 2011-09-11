module SqlHandler

let ParseSql x = 
    let lexbuf = Lexing.LexBuffer<_>.FromString x
    let y = SqlParser.start SqlLexer.tokenize lexbuf   
    y