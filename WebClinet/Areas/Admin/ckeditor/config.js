/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	// Define changes to default configuration here.
	// For complete reference see:
	// https://ckeditor.com/docs/ckeditor4/latest/api/CKEDITOR_config.html
	// L??c  b? các th? p tr??c from //
	config.enterMode = CKEDITOR.ENTER_BR;
	// The toolbar groups arrangement, optimized for two toolbar rows.
	//config.toolbarGroups = [
	//	{ name: 'clipboard', groups: ['clipboard', 'undo'] },
	//	{ name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
	//	{ name: 'links' },
	//	{ name: 'insert' },
	//	{ name: 'forms' },
	//	{ name: 'tools' },
	//	{ name: 'document', groups: ['mode', 'document', 'doctools'] },
	//	{ name: 'others' },
	//	'/',
	//	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
	//	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
	//	{ name: 'styles' },
	//	{ name: 'colors' },
	//	{ name: 'about' }
	//];

	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
	// Cau hinh vs CKfinder

	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/uploads';
	config.filebrowserFlashUploadUrl = '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

	CKFinder.setupCKEditor(null, '/Areas/Admin/ckfinder_aspnet_2.6.2.1/ckfinder/');
};
