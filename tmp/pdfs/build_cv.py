from reportlab.lib import colors
from reportlab.lib.pagesizes import A4
from reportlab.lib.styles import getSampleStyleSheet, ParagraphStyle
from reportlab.lib.units import cm
from reportlab.platypus import SimpleDocTemplate, Paragraph, Spacer, Table, TableStyle

OUT = r'C:\Users\Adham Saber\source\repos\DVLD\output\pdf\adham_saber_cv.pdf'
NAVY = colors.HexColor('#173B5C')
BLUE = colors.HexColor('#2E78B7')
INK = colors.HexColor('#1F2937')
MUTED = colors.HexColor('#526170')
LINE = colors.HexColor('#CBD5E1')

styles = getSampleStyleSheet()
styles.add(ParagraphStyle(name='Name', parent=styles['Title'], fontName='Helvetica-Bold', fontSize=23, leading=27, textColor=NAVY, spaceAfter=2))
styles.add(ParagraphStyle(name='Role', parent=styles['Normal'], fontName='Helvetica', fontSize=11, leading=14, textColor=BLUE, spaceAfter=7))
styles.add(ParagraphStyle(name='Contact', parent=styles['Normal'], fontName='Helvetica', fontSize=8.8, leading=11, textColor=MUTED, spaceAfter=11))
styles.add(ParagraphStyle(name='H', parent=styles['Heading2'], fontName='Helvetica-Bold', fontSize=11.5, leading=14, textColor=NAVY, spaceBefore=8, spaceAfter=5, borderWidth=0, borderPadding=0))
styles.add(ParagraphStyle(name='Body', parent=styles['BodyText'], fontName='Helvetica', fontSize=9.4, leading=13.2, textColor=INK, spaceAfter=4))
styles.add(ParagraphStyle(name='Small', parent=styles['BodyText'], fontName='Helvetica', fontSize=8.9, leading=12, textColor=INK, spaceAfter=3))
styles.add(ParagraphStyle(name='Meta', parent=styles['BodyText'], fontName='Helvetica-Oblique', fontSize=8.7, leading=11.2, textColor=MUTED, spaceAfter=3))

def footer(c, doc):
    c.saveState()
    c.setStrokeColor(LINE); c.line(1.55*cm, 1.25*cm, A4[0]-1.55*cm, 1.25*cm)
    c.setFont('Helvetica', 7.8); c.setFillColor(MUTED)
    c.drawString(1.55*cm, .82*cm, 'Adham Saber Tawfik Hassan - Curriculum Vitae')
    c.drawRightString(A4[0]-1.55*cm, .82*cm, f'Page {doc.page}')
    c.restoreState()

def section(title):
    return [Spacer(1,2), Paragraph(title, styles['H'])]

def build():
    doc = SimpleDocTemplate(OUT, pagesize=A4, leftMargin=1.55*cm, rightMargin=1.55*cm, topMargin=1.4*cm, bottomMargin=1.65*cm)
    flow = []
    flow += [
        Paragraph('Adham Saber Tawfik Hassan', styles['Name']),
        Paragraph('Computer Science Student | Aspiring .NET Developer', styles['Role']),
        Paragraph('Cairo, Egypt &nbsp;&nbsp;|&nbsp;&nbsp; 01156994160 &nbsp;&nbsp;|&nbsp;&nbsp; adhamsaber2367@gmail.com<br/>LinkedIn: linkedin.com/in/adham-saber-857616334 &nbsp;&nbsp;|&nbsp;&nbsp; GitHub: github.com/AdhamSaber2357', styles['Contact'])
    ]
    flow += section('Professional Summary')
    flow += [Paragraph('Motivated Computer Science student at Cairo University with a strong foundation in C++ problem solving and a growing focus on .NET development. Currently learning C#, delegates, and Windows Forms, while building a DVLD desktop application. Seeking an internship or junior opportunity to apply software-development fundamentals, learn from an engineering team, and contribute to practical .NET applications.', styles['Body'])]
    flow += section('Education')
    flow += [
        Paragraph('<b>B.Sc. in Computer Science and Information</b> - Cairo University', styles['Body']),
        Paragraph('Third-year student | Overall grade: Very Good', styles['Meta'])
    ]
    flow += section('Technical Skills')
    skills = [
        [Paragraph('<b>Programming Languages</b>', styles['Small']), Paragraph('C++, C#', styles['Small'])],
        [Paragraph('<b>.NET Development</b>', styles['Small']), Paragraph('.NET fundamentals, C# delegates, Windows Forms', styles['Small'])],
        [Paragraph('<b>Problem Solving</b>', styles['Small']), Paragraph('C++ problem-solving practice and algorithmic thinking', styles['Small'])],
        [Paragraph('<b>Tools</b>', styles['Small']), Paragraph('Git, GitHub', styles['Small'])],
    ]
    t = Table(skills, colWidths=[4.1*cm, 12.1*cm])
    t.setStyle(TableStyle([('VALIGN',(0,0),(-1,-1),'TOP'),('LINEBELOW',(0,0),(-1,-1),.35,LINE),('LEFTPADDING',(0,0),(-1,-1),0),('RIGHTPADDING',(0,0),(-1,-1),4),('TOPPADDING',(0,0),(-1,-1),3),('BOTTOMPADDING',(0,0),(-1,-1),4)]))
    flow += [t]
    flow += section('Projects')
    flow += [
        Paragraph('<b>DVLD - Driving and Vehicle License Department System</b>', styles['Body']),
        Paragraph('Desktop application in progress using C# and Windows Forms. Applying object-oriented programming and .NET concepts while building a practical management-system project. Source code: github.com/AdhamSaber2357', styles['Small'])
    ]
    flow += section('Learning and Development')
    flow += [
        Paragraph('<b>.NET Development Track</b>', styles['Body']),
        Paragraph('Actively studying C# and .NET concepts, including delegates and Windows Forms, and applying them in project work.', styles['Small']),
        Paragraph('<b>C++ Problem-Solving Practice</b>', styles['Body']),
        Paragraph('Developed programming fundamentals through solving problems in C++, strengthening logic, debugging, and algorithmic thinking.', styles['Small'])
    ]
    flow += section('Links')
    flow += [
        Paragraph('LinkedIn: <link href="https://www.linkedin.com/in/adham-saber-857616334?utm_source=share_via&amp;utm_content=profile&amp;utm_medium=member_android" color="#2E78B7">linkedin.com/in/adham-saber-857616334</link>', styles['Small']),
        Paragraph('GitHub: <link href="https://github.com/AdhamSaber2357" color="#2E78B7">github.com/AdhamSaber2357</link>', styles['Small'])
    ]
    doc.build(flow, onFirstPage=footer, onLaterPages=footer)

if __name__ == '__main__':
    build()
