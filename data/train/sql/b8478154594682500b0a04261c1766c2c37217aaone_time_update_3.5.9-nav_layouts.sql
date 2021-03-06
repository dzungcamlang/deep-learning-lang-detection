insert into nav_layouts ( introtext_id ) select distinct moduleid from nav where !isnull(moduleid) and moduleid !='' and navid != '' and !isnull(navid) order by moduleid;
insert into nav_layouts ( class_id ) select distinct classlist from nav where !isnull(classlist) and classlist !='' and navid != '' and !isnull(navid) order by classlist;
insert into nav_layouts ( section_id ) select distinct typeid from nav where !isnull(typeid) and typeid !='' and navid != '' and !isnull(navid) order by typeid;
insert into nav_layouts ( section_id_list ) select distinct typelist from nav where !isnull(typelist) and typelist !='' and navid != '' and !isnull(navid) order by typelist;
update nav_layouts a, moduletext b set a.name = b.name where a.introtext_id = b.id;
update nav_layouts set name = 'Standard' where introtext_id = 1;
update nav_layouts set name = 'Front Page' where introtext_id = 2;
update nav_layouts a, class b set a.name = b.class where a.class_id = b.id;
update nav_layouts a, articletype b set a.name = b.type where a.section_id = b.id;
update nav_layouts a, articletype b set a.name = Concat( b.type, ' List' ) where a.section_id_list = b.id;
update nav a, nav_layouts b set a.layout_id = b.id where a.moduleid = b.introtext_id;
update nav a, nav_layouts b set a.layout_id = b.id where a.classlist = b.class_id;
update nav a, nav_layouts b set a.layout_id = b.id where a.typelist= b.section_id_list;
update nav a, nav_layouts b set a.layout_id = b.id where a.typeid= b.section_id;
delete from nav_layouts where name='' or isnull(name);
