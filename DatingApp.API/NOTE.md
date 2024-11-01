# Authen
    -   Luu password sao cho an toàn ? ==> hash (hàm băm )
    -   Tại sao k mã hóa mà băm ?  ==> password k muốn ai biet , băm -> chuỗi đi 1 chiều Plain Text(pass) sang Cipher Text , không có chiều ngược lại. Nếu dùng mã hóa -> nếu hacker có key -> dịch ngc lại password
    -   Salt : nếu password ngắn , thì + salt để làm pass dài hơn, khó đoan hơn

# TOKEN 
    - Header : 
        +   chuoi byte64
        +   type of token
        +   loai thuat toan
    - Payload: 
        +   chuoi byte64
        +   chua thong tin 
    - verify signature:
        +   token secret

    => nếu payload bị thay đổi băm ra signature khác -> không validate dc, loi
    




