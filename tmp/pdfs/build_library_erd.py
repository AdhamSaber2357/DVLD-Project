from reportlab.lib import colors
from reportlab.lib.pagesizes import A4
from reportlab.lib.styles import getSampleStyleSheet, ParagraphStyle
from reportlab.lib.units import cm
from reportlab.platypus import SimpleDocTemplate, Paragraph, Spacer, Table, TableStyle, PageBreak, Flowable

OUT=r'C:\Users\Adham Saber\source\repos\DVLD\output\pdf\general_library_management_erd.pdf'
W,H=A4; NAVY=colors.HexColor('#123B5D'); BLUE=colors.HexColor('#2878B5'); PALE=colors.HexColor('#E8F2FA'); INK=colors.HexColor('#172033'); GREY=colors.HexColor('#536274')
s=getSampleStyleSheet()
s.add(ParagraphStyle(name='T',parent=s['Title'],fontName='Helvetica-Bold',fontSize=21,leading=25,textColor=NAVY,spaceAfter=7))
s.add(ParagraphStyle(name='ST',parent=s['Normal'],fontName='Helvetica',fontSize=10,leading=13,textColor=GREY,spaceAfter=12))
s.add(ParagraphStyle(name='H',parent=s['Heading2'],fontName='Helvetica-Bold',fontSize=13.5,leading=17,textColor=NAVY,spaceBefore=8,spaceAfter=5))
s.add(ParagraphStyle(name='B',parent=s['BodyText'],fontName='Helvetica',fontSize=9.2,leading=12.5,textColor=INK,spaceAfter=4))
s.add(ParagraphStyle(name='SM',parent=s['BodyText'],fontName='Helvetica',fontSize=8,leading=10.3,textColor=INK))

def footer(c,d):
    c.saveState(); c.setStrokeColor(colors.HexColor('#CBD5E1')); c.line(40,35,W-40,35); c.setFont('Helvetica',8); c.setFillColor(GREY)
    c.drawString(40,22,'General Library Management System - ERD Proposal'); c.drawRightString(W-40,22,f'Page {d.page}'); c.restoreState()

def box(c,x,y,title,attrs,w=110):
    h=19+len(attrs)*9+7
    c.setFillColor(colors.white); c.setStrokeColor(NAVY); c.setLineWidth(1); c.roundRect(x,y-h,w,h,4,stroke=1,fill=1)
    c.setFillColor(NAVY); c.rect(x,y-19,w,19,fill=1,stroke=0); c.setFillColor(colors.white); c.setFont('Helvetica-Bold',7.4); c.drawCentredString(x+w/2,y-13,title)
    yy=y-28
    for a in attrs:
        c.setFillColor(INK); c.setFont('Helvetica-Bold' if a.startswith('PK') else 'Helvetica',6.7); c.drawString(x+5,yy,a); yy-=9

def rel(c,x,y,label,sub=''):
    q=23; c.setStrokeColor(BLUE); c.setFillColor(PALE); p=c.beginPath(); p.moveTo(x,y+q); p.lineTo(x+q,y); p.lineTo(x,y-q); p.lineTo(x-q,y); p.close(); c.drawPath(p,1,1)
    c.setFillColor(NAVY); c.setFont('Helvetica-Bold',6.5); c.drawCentredString(x,y+1,label)
    if sub: c.setFont('Helvetica',5.7); c.drawCentredString(x,y-7,sub)

def edge(c,x1,y1,x2,y2,a,b,ta=False,tb=False):
    c.setStrokeColor(INK); c.setLineWidth(.7); c.line(x1,y1,x2,y2)
    dx=x2-x1;dy=y2-y1; L=max((dx*dx+dy*dy)**.5,1); px=-dy/L*2.4;py=dx/L*2.4
    if ta: c.line(x1+px,y1+py,x1+dx*.23+px,y1+dy*.23+py)
    if tb: c.line(x2+px,y2+py,x2-dx*.23+px,y2-dy*.23+py)
    c.setFillColor(INK);c.setFont('Helvetica-Bold',7);c.drawCentredString(x1+dx*.14+px*2,y1+dy*.14+py*2,a);c.drawCentredString(x2-dx*.14+px*2,y2-dy*.14+py*2,b)

class Diagram(Flowable):
    def __init__(self): super().__init__(); self.width=W; self.height=H
    def wrap(self,a,b): return a,b
    def draw(self):
        c=self.canv; c.saveState(); c.translate(-40,-45)
        c.setFont('Helvetica-Bold',17);c.setFillColor(NAVY);c.drawString(40,H-15,'ERD - General Library Management System')
        c.setFont('Helvetica',8);c.setFillColor(GREY);c.drawString(40,H-29,'Single line = partial participation. A second parallel segment next to an entity = total participation.')
        # Eleven entity boxes across three tiers.
        box(c,42,765,'BRANCH',['PK: BranchID','BranchName','Address','Phone'],92)
        box(c,187,765,'PUBLISHER',['PK: PublisherID','PublisherName','Phone','Email'],97)
        box(c,347,765,'CATEGORY',['PK: CategoryID','CategoryName'],90)
        box(c,482,765,'AUTHOR',['PK: AuthorID','AuthorName','Nationality'],90)
        box(c,42,610,'BOOK',['PK: BookID','ISBN','Title','PublishYear','Edition'],92)
        box(c,187,610,'BOOK_COPY',['PK: CopyID','Barcode','CopyStatus','BookID FK','BranchID FK'],97)
        box(c,347,610,'MEMBER',['PK: MemberID','FullName','Email','Phone','JoinDate'],90)
        box(c,482,610,'LIBRARIAN',['PK: LibrarianID','FullName','Email','Salary','BranchID FK'],100)
        box(c,85,400,'LOAN',['PK: LoanID','LoanDate','DueDate','ReturnDate','CopyID FK','MemberID FK','LibrarianID FK'],115)
        box(c,282,400,'RESERVATION',['PK: ReservationID','ReserveDate','Status','BookID FK','MemberID FK'],110)
        box(c,470,400,'FINE',['PK: FineID','Amount','FineDate','PaidStatus','LoanID FK'],100)
        # relationship diamonds and connectors (cardinality, total shown by duplicate segment)
        rel(c,122,690,'HAS'); edge(c,88,720,105,713,'1','M',False,True); edge(c,139,690,187,572,'','',False,True)
        rel(c,234,690,'PUBLISHES'); edge(c,235,720,234,713,'1','M',False,True); edge(c,257,690,88,572,'','',False,True)
        rel(c,390,690,'CLASSIFIES'); edge(c,392,720,390,713,'1','M',False,True); edge(c,367,690,134,572,'','',False,True)
        rel(c,505,690,'WRITES'); edge(c,527,720,522,713,'M','M',False,False); edge(c,482,690,134,572,'','',False,False)
        rel(c,220,525,'STORED AT'); edge(c,225,541,230,572,'M','1',True,False); edge(c,197,525,134,720,'','',False,False)
        rel(c,317,525,'REGISTERS'); edge(c,347,572,340,548,'1','M',False,True); edge(c,294,525,145,355,'','',False,True)
        rel(c,435,525,'WORKS AT'); edge(c,482,572,458,546,'M','1',True,False); edge(c,412,525,134,720,'','',False,False)
        rel(c,172,325,'BORROWS'); edge(c,142,355,152,348,'1','M',False,True); edge(c,195,325,142,275,'','',False,True)
        rel(c,235,325,'IS FOR'); edge(c,187,572,212,348,'1','M',False,True); edge(c,258,325,200,275,'','',False,True)
        rel(c,330,325,'PLACES'); edge(c,347,572,330,348,'1','M',False,True); edge(c,353,325,337,275,'','',False,True)
        rel(c,402,325,'FOR'); edge(c,88,572,379,348,'1','M',False,True); edge(c,425,325,337,275,'','',False,True)
        rel(c,440,325,'PROCESSES'); edge(c,482,572,463,348,'1','M',False,True); edge(c,417,325,200,275,'','',False,True)
        rel(c,455,270,'GENERATES'); edge(c,200,275,432,270,'1','0..1',False,True); edge(c,478,270,520,355,'','',False,True)
        c.setFont('Helvetica-Bold',8);c.setFillColor(NAVY);c.drawString(42,112,'Reading the model')
        c.setFont('Helvetica',7.8);c.setFillColor(INK);c.drawString(42,98,'BOOK and AUTHOR are M:N through WRITES. Relationship attributes are not required in this relationship.')
        c.drawString(42,86,'LOAN and RESERVATION are associative entities with their own attributes and foreign keys.')
        c.drawString(42,74,'A Fine is optional for each Loan (0..1), but every Fine must refer to one Loan.')
        c.restoreState(); footer(c,type('D',(),{'page':2})())

def make_table(rows,widths):
    t=Table(rows,colWidths=widths,repeatRows=1); t.setStyle(TableStyle([('BACKGROUND',(0,0),(-1,0),PALE),('GRID',(0,0),(-1,-1),.35,colors.HexColor('#C7D3DF')),('VALIGN',(0,0),(-1,-1),'TOP'),('LEFTPADDING',(0,0),(-1,-1),5),('RIGHTPADDING',(0,0),(-1,-1),5),('TOPPADDING',(0,0),(-1,-1),4),('BOTTOMPADDING',(0,0),(-1,-1),4)]));return t

def build():
    d=SimpleDocTemplate(OUT,pagesize=A4,leftMargin=40,rightMargin=40,topMargin=42,bottomMargin=46)
    st=[Paragraph('General Library Management System',s['T']),Paragraph('A complete project proposal with requirements, ERD, participation constraints, and relational schema.',s['ST']),Paragraph('1. Project overview',s['H']),Paragraph('This system supports a public library with multiple branches. It manages books and copies, authors, publishers, categories, library members, loans, reservations, employees, and fines.',s['B']),Paragraph('2. Business requirements',s['H'])]
    data=[[Paragraph('<b>#</b>',s['SM']),Paragraph('<b>Requirement</b>',s['SM'])]]
    R=['The library has many branches. Each Branch has BranchID, BranchName, Address, and Phone.','The library stores books. Each Book has BookID, ISBN, Title, PublishYear, and Edition.','Each physical BookCopy belongs to one Book and is stored in one Branch. A book and branch can each have many copies.','Each Book is published by one Publisher. A Publisher may publish many books.','Each Book belongs to one Category; a Category may contain many books.','A Book can be written by many Authors, and an Author can write many Books.','Members have MemberID, FullName, Email, Phone, and JoinDate. A member can borrow many copies over time.','Each Loan records LoanID, LoanDate, DueDate, ReturnDate, and is for one BookCopy, one Member, and one Librarian.','Librarians have LibrarianID, FullName, Email, Salary, and work in one Branch. A branch may employ many librarians.','Members may place Reservations for books. Each Reservation records ReservationID, ReserveDate, and Status.','A Loan may generate at most one Fine. A Fine stores FineID, Amount, FineDate, and PaidStatus.']
    data += [[Paragraph(str(i+1),s['SM']),Paragraph(x,s['SM'])] for i,x in enumerate(R)];st += [make_table(data,[.55*cm,16.25*cm]),PageBreak(),Diagram(),PageBreak()]
    st += [Paragraph('3. Design explanation',s['T']),Paragraph('Entities (11)',s['H']),Paragraph('BRANCH, PUBLISHER, CATEGORY, AUTHOR, BOOK, BOOK_COPY, MEMBER, LIBRARIAN, LOAN, RESERVATION, and FINE. BOOK_COPY represents a physical item, separating a book title from the copies held in specific branches.',s['B']),Paragraph('Cardinality and participation',s['H'])]
    rows=[[Paragraph('<b>Relationship</b>',s['SM']),Paragraph('<b>Rule</b>',s['SM'])]]
    X=[('Branch - BookCopy','1:M; BookCopy total, Branch partial.'),('Publisher - Book','1:M; Book total, Publisher partial.'),('Category - Book','1:M; Book total, Category partial.'),('Author - Book','M:N; both sides partial.'),('Member - Loan','1:M; Loan total, Member partial.'),('BookCopy - Loan','1:M; Loan total, BookCopy partial.'),('Librarian - Loan','1:M; Loan total, Librarian partial.'),('Member - Reservation','1:M; Reservation total, Member partial.'),('Book - Reservation','1:M; Reservation total, Book partial.'),('Loan - Fine','1:0..1; Fine total, Loan partial.')]
    rows += [[Paragraph(a,s['SM']),Paragraph(b,s['SM'])] for a,b in X];st += [make_table(rows,[5.0*cm,11.8*cm]),Paragraph('4. Relational schema',s['H'])]
    schema='''BRANCH(<b>BranchID</b>, BranchName, Address, Phone)<br/>PUBLISHER(<b>PublisherID</b>, PublisherName, Phone, Email)<br/>CATEGORY(<b>CategoryID</b>, CategoryName)<br/>AUTHOR(<b>AuthorID</b>, AuthorName, Nationality)<br/>BOOK(<b>BookID</b>, ISBN, Title, PublishYear, Edition, PublisherID FK, CategoryID FK)<br/>BOOK_COPY(<b>CopyID</b>, Barcode, CopyStatus, BookID FK, BranchID FK)<br/>MEMBER(<b>MemberID</b>, FullName, Email, Phone, JoinDate)<br/>LIBRARIAN(<b>LibrarianID</b>, FullName, Email, Salary, BranchID FK)<br/>BOOK_AUTHOR(<b>BookID FK</b>, <b>AuthorID FK</b>)<br/>LOAN(<b>LoanID</b>, LoanDate, DueDate, ReturnDate, CopyID FK, MemberID FK, LibrarianID FK)<br/>RESERVATION(<b>ReservationID</b>, ReserveDate, Status, BookID FK, MemberID FK)<br/>FINE(<b>FineID</b>, Amount, FineDate, PaidStatus, LoanID FK UNIQUE)'''
    st += [Paragraph(schema,s['B']),Paragraph('Implementation note: BOOK_AUTHOR resolves the M:N WRITES relationship. The UNIQUE constraint on FINE.LoanID enforces that a loan can generate no more than one fine.',s['B'])]
    d.build(st,onFirstPage=footer,onLaterPages=footer)
if __name__=='__main__': build()
