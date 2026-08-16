import html
import re
import zipfile

with zipfile.ZipFile('tmp/Mapping-Day2.ppt') as deck:
    slides = sorted(
        name for name in deck.namelist()
        if name.startswith('ppt/slides/slide') and name.endswith('.xml')
    )
    for name in slides:
        source = deck.read(name).decode('utf-8', 'ignore')
        words = re.findall(r'<a:t>(.*?)</a:t>', source)
        print(f'\n{name}\n' + html.unescape(' '.join(words)))
