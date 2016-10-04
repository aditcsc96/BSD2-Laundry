--kode trans
create or replace function autogenkodetrans(temptanggal IN varchar2)
	return varchar2
	is 
		tempkodetransaksi varchar2(20);
		cotr number(5) default 0;
		nmr varchar2(5);
		tempkode varchar2(20);
		
	begin
		tempkodetransaksi := substr(temptanggal,0,6);
		select max(substr(kodetrans,7,2)) into cotr from ttransaksi where kodetrans like tempkodetransaksi || '%';
		if cotr IS NULL then
			nmr := '01';
		else
			cotr := cotr + 1;
			nmr := '0' || cotr;
		end if;
		
		tempkode := tempkodetransaksi || nmr;
		return tempkode;
	end;
	/
	show err;
	
	select autogenkodetrans('150904') from dual;

--id member	
create or replace trigger autogenidmember
before insert
on tmember
for each row
	declare
		tempkode varchar2(10);
		ctr number(5) default 0;
		nmr varchar2(5);
		temp varchar2(10);
	begin
		tempkode := upper(substr(:new.nama,0,2));
		select max(substr(idmember,3,3)) into ctr from tmember where idmember like tempkode || '%';
		if ctr IS NULL then
			nmr := '001';
		else
			ctr := ctr + 1;
			nmr := '00' || ctr;
		end if;
		:new.idmember := upper(substr(:new.nama,0,2)) || nmr;
	end;
	/
show err;
insert into tmember (idmember, nama, alamat, telp, tgllahir, jk) values (' ','DADANG', 'NGAGEL', 4567, TO_DATE('11/05/1995', 'dd-mm-yyyy'), 'PRIA');
commit;