<script type="text/javascript">

var ewa;

function ewaStart(){
 Ewa.EwaControl.add_applicationReady(ewaConnect);
}

function ewaConnect() {
    ewa = Ewa.EwaControl.getInstances().getItem(0);
    if (ewa) {ewa.add_activeCellChanged(ewaCellChanged);}
}

function ewaCellChanged(rangeArgs) {
    var sheetName = rangeArgs.getRange().getSheet().getName();
    var col = rangeArgs.getRange().getColumn();
    var row = rangeArgs.getRange().getRow();
    var value = rangeArgs.getFormattedValues();
    alert('Active Cell is now at Row' + (row + 1) + 
          ', Column' + (col + 1) + ', with Value of ' + value);
}

ewaStart();

</script>
