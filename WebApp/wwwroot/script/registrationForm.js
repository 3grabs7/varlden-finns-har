function mark(e) {
    e.target.childNodes[1].checked = !e.target.childNodes[1].checked
    e.target.classList.toggle('marked')

}