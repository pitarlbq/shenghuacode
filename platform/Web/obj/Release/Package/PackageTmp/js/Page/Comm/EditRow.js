var tt_editIndex = undefined, currentSelectIndex = 0, totalIndex = 0, isKeyPress = false, TimeoutTimer1 = null, TimeoutTimer2 = null, currentField = null, fieldList = [];
$(function () {
    $(window).focus();
    onKeyDown();
});
$.extend($.fn.datagrid.methods, {
    editCell: function (jq, param) {
        return jq.each(function () {
            var fields = $(this).datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor1 = col.editor;
                if (fields[i] != param.field) {
                    col.editor = null;
                }
            }
            $(this).datagrid('beginEdit', param.index);
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor = col.editor1;
            }
        });
    }
});
function getFieldList() {
    for (var i = 0; i < finalcolumn.length; i++) {
        for (var j = 0; j < finalcolumn[i].length; j++) {
            if (finalcolumn[i][j].editor) {
                fieldList.push(finalcolumn[i][j]);
            }
        }
    }
}
function endTTEditing() {
    if (tt_editIndex == undefined) {
        return;
    }
    $(dgId).datagrid('endEdit', tt_editIndex);
    tt_editIndex = undefined;
}
function onKeyDown() {
    $(window).keydown(function (e) {
        if (e.keyCode != 13 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40) {
            return;
        }
        e.preventDefault();
        var goType = 0;//1-右键头2-左箭头3-上箭头4-下箭头5-回车
        if (e.keyCode == 39) {
            goType = 1;
        } else if (e.keyCode == 37) {
            goType = 2;
        }
        else if (e.keyCode == 38) {
            goType = 3;
        }
        else if (e.keyCode == 40) {
            goType = 4;
        }
        else if (e.keyCode == 13) {
            goType = 5;
        }
        if (goType == 5) {
            if (tt_editIndex == undefined) {
                do_edit_row();
                return;
            }
            endTTEditing();
            setCalculateValue();
            do_save_row();
            return;
        }
        if (goType == 3 || goType == 4) {
            isKeyPress = true;
            clearTimeout(TimeoutTimer1);
            clearTimeout(TimeoutTimer2);
            TimeoutTimer1 = setTimeout(function () {
                isKeyPress = false;
            }, 100);
        }
        if (goType == 3) {
            endTTEditing();
            setCalculateValue();
            if (currentSelectIndex > 0) {
                currentSelectIndex--;
            }
            $(dgId).datagrid('unselectAll');
            $(dgId).datagrid('selectRow', currentSelectIndex);
            do_edit_row();
            return;
        }
        if (goType == 4) {
            endTTEditing();
            setCalculateValue();
            var rows = $(dgId).datagrid('getRows');
            if (currentSelectIndex < rows.length - 1) {
                currentSelectIndex++;
                $(dgId).datagrid('unselectAll');
                $(dgId).datagrid('selectRow', currentSelectIndex);
                do_edit_row();
            }
            else {
                do_add_row();
            }
            return;
        }
        if (tt_editIndex == undefined) {
            return;
        }
        var elems = $(document.activeElement).parents('td');
        var fieldName = '';
        $.each(elems, function (index, elem) {
            if ($(elem).attr('field')) {
                fieldName = $(elem).attr('field');
                return false;
            }
        })
        var currentIndex = -1;
        if (fieldList.length > 0) {
            $.each(fieldList, function (index, column) {
                if (fieldName == '') {
                    currentField = column;
                    currentIndex = 0;
                    return false;
                } else if (column.field == fieldName) {
                    currentIndex = index;
                    currentField = column;
                    return false;
                }
            })
        }
        endTTEditing();
        setCalculateValue();
        if (currentIndex > -1) {
            currentField = getNextField(currentIndex, goType);
        }
        if (currentField) {
            fieldName = currentField.field;
            onEditCell(currentSelectIndex);
            var Field_Target = $(dgId).datagrid('getEditor', { index: currentSelectIndex, field: fieldName });
            if (Field_Target) {
                Field_Target.target.next('span').find('input').focus();
            }
        }
    });
}
function getNextField(currentIndex, goType) {
    if (goType == 1) {
        currentIndex++;
        for (var i = currentIndex; i < fieldList.length; i++) {
            if (fieldList[i].editor) {
                return fieldList[i];
            }
        }
        for (var i = fieldList.length - 1; i >= 0; i--) {
            if (fieldList[i].editor) {
                return fieldList[i];
            }
        }
    }
    if (goType == 2) {
        currentIndex--;
        for (var i = currentIndex; i >= 0; i--) {
            if (fieldList[i].editor) {
                return fieldList[i];
            }
        }
        for (var i = 0; i < fieldList.length; i++) {
            if (fieldList[i].editor) {
                return fieldList[i];
            }
        }
    }
    return null;
}
function onClickCell(index, field) {
    for (var i = 0; i < fieldList.length; i++) {
        if (fieldList[i].editor && field == fieldList[i].field) {
            currentField = fieldList[i];
            break;
        }
    }
    setTimeout(function () {
        onEditCell(index);
    }, 200);
}
function onEditCell(index, row) {
    currentSelectIndex = index;
    if (!currentField) {
        for (var i = 0; i < fieldList.length; i++) {
            if (fieldList[i].editor) {
                currentField = fieldList[i];
                break;
            }
        }
    }
    endTTEditing();
    $(dgId).datagrid('editCell', { index: index, field: currentField.field });
    tt_editIndex = index;
    var fieldName = currentField.field;
    var Field_Target = $(dgId).datagrid('getEditor', { index: tt_editIndex, field: fieldName });
    if (Field_Target) {
        var Field_Input = Field_Target.target.next('span').find('input');
        Field_Input.focus();
    }
    if (currentField.formatter) {
        var fn = currentField.formatter;
        if (typeof fn == 'function') {
            var rows = $(dgId).datagrid('getRows');
            row = rows[index];
            row[currentField.field + '_Editor'] = true;
            var value = fn(row[currentField.field], row);
            value = value == '--' ? '' : value;
            var target = $(dgId).datagrid('getEditor', { index: tt_editIndex, field: currentField.field }).target;
            if (currentField.editor.type == 'combobox') {
                target.combobox('setValue', value);
            } else if (currentField.editor.type == 'datebox') {
                target.datebox('setValue', value);
            } else {
                target.textbox('setValue', value);
            }
        }
    }
}
function do_add_row() {
    if (!canInsert) {
        return;
    }
    $(dgId).datagrid('appendRow', {
        ID: 0
    });
    totalIndex++;
    $(dgId).datagrid('selectRow', totalIndex);
    do_edit_row();
}
function do_edit_row() {
    if (isKeyPress) {
        TimeoutTimer2 = setTimeout(function () {
            do_edit_row();
        }, 100);
        return;
    }
    endTTEditing();
    var row = $(dgId).datagrid('getSelected');
    if (row == null) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var rowIndex = $(dgId).datagrid('getRowIndex', row);
    //$(dgId).datagrid('beginEdit', rowIndex);
    if (!currentField) {
        for (var i = 0; i < fieldList.length; i++) {
            if (fieldList[i].editor) {
                currentField = fieldList[i];
                break;
            }
        }
    }
    if (currentField) {
        onEditCell(rowIndex, currentField, row);
    }
}
function setCalculateValue() {
    if (!currentField) {
        return;
    }
    var fieldName = currentField.field;
    if (fieldName == 'CalculateUnitPrice' || fieldName == 'CalculateUseCount' || fieldName == 'CalculateStartTime' || fieldName == 'CalculateEndTime') {
        var rows = $(dgId).datagrid('getRows');
        row = rows[currentSelectIndex];
        calculateEditRowCost(currentSelectIndex, fieldName, row);
    }
}