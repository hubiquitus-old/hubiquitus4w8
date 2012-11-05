/*
 * Copyright (c) Novedia Group 2012.
 *
 *     This file is part of Hubiquitus.
 *
 *     Hubiquitus is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     Hubiquitus is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with Hubiquitus.  If not, see <http://www.gnu.org/licenses/>.
 */



namespace hubiquitus4w8.hapi.test
{
    partial class testForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.connectBt = new System.Windows.Forms.Button();
            this.disconnectBt = new System.Windows.Forms.Button();
            this.subscribeBt = new System.Windows.Forms.Button();
            this.unsubscribeBt = new System.Windows.Forms.Button();
            this.publisherBt = new System.Windows.Forms.Button();
            this.getLastMsgsBt = new System.Windows.Forms.Button();
            this.getSubscriptionsBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.serverHostTextBox = new System.Windows.Forms.TextBox();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.channelIDTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nbLastMessagesTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.convidTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.filterNameTextBox = new System.Windows.Forms.TextBox();
            this.filterAttrTextBox = new System.Windows.Forms.TextBox();
            this.filterValueTextBox = new System.Windows.Forms.TextBox();
            this.getThreadBt = new System.Windows.Forms.Button();
            this.getThreadsBt = new System.Windows.Forms.Button();
            this.setFilterBt = new System.Windows.Forms.Button();
            this.listFilterBt = new System.Windows.Forms.Button();
            this.unSetFilterBt = new System.Windows.Forms.Button();
            this.getRelevantMsgBt = new System.Windows.Forms.Button();
            this.commandBt = new System.Windows.Forms.Button();
            this.transientRBt = new System.Windows.Forms.RadioButton();
            this.console = new System.Windows.Forms.TextBox();
            this.pubConvStateBt = new System.Windows.Forms.Button();
            this.notTransientRBt = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(155, 9);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(447, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(155, 41);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(447, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // connectBt
            // 
            this.connectBt.Location = new System.Drawing.Point(15, 506);
            this.connectBt.Name = "connectBt";
            this.connectBt.Size = new System.Drawing.Size(75, 23);
            this.connectBt.TabIndex = 4;
            this.connectBt.Text = "connect";
            this.connectBt.UseVisualStyleBackColor = true;
            this.connectBt.Click += new System.EventHandler(this.connectBt_Click);
            // 
            // disconnectBt
            // 
            this.disconnectBt.Location = new System.Drawing.Point(99, 506);
            this.disconnectBt.Name = "disconnectBt";
            this.disconnectBt.Size = new System.Drawing.Size(75, 23);
            this.disconnectBt.TabIndex = 5;
            this.disconnectBt.Text = "disconnect";
            this.disconnectBt.UseVisualStyleBackColor = true;
            this.disconnectBt.Click += new System.EventHandler(this.disconnectBt_Click);
            // 
            // subscribeBt
            // 
            this.subscribeBt.Location = new System.Drawing.Point(261, 506);
            this.subscribeBt.Name = "subscribeBt";
            this.subscribeBt.Size = new System.Drawing.Size(75, 23);
            this.subscribeBt.TabIndex = 6;
            this.subscribeBt.Text = "subscribe";
            this.subscribeBt.UseVisualStyleBackColor = true;
            this.subscribeBt.Click += new System.EventHandler(this.subscribeBt_Click);
            // 
            // unsubscribeBt
            // 
            this.unsubscribeBt.Location = new System.Drawing.Point(180, 535);
            this.unsubscribeBt.Name = "unsubscribeBt";
            this.unsubscribeBt.Size = new System.Drawing.Size(75, 23);
            this.unsubscribeBt.TabIndex = 7;
            this.unsubscribeBt.Text = "unsubscribe";
            this.unsubscribeBt.UseVisualStyleBackColor = true;
            this.unsubscribeBt.Click += new System.EventHandler(this.unsubscribeBt_Click);
            // 
            // publisherBt
            // 
            this.publisherBt.Location = new System.Drawing.Point(342, 506);
            this.publisherBt.Name = "publisherBt";
            this.publisherBt.Size = new System.Drawing.Size(75, 23);
            this.publisherBt.TabIndex = 8;
            this.publisherBt.Text = "publisher";
            this.publisherBt.UseVisualStyleBackColor = true;
            this.publisherBt.Click += new System.EventHandler(this.publisherBt_Click);
            // 
            // getLastMsgsBt
            // 
            this.getLastMsgsBt.Location = new System.Drawing.Point(423, 506);
            this.getLastMsgsBt.Name = "getLastMsgsBt";
            this.getLastMsgsBt.Size = new System.Drawing.Size(75, 23);
            this.getLastMsgsBt.TabIndex = 9;
            this.getLastMsgsBt.Text = "getLastMsgs";
            this.getLastMsgsBt.UseVisualStyleBackColor = true;
            this.getLastMsgsBt.Click += new System.EventHandler(this.getLastMsgsBt_Click);
            // 
            // getSubscriptionsBt
            // 
            this.getSubscriptionsBt.Location = new System.Drawing.Point(504, 506);
            this.getSubscriptionsBt.Name = "getSubscriptionsBt";
            this.getSubscriptionsBt.Size = new System.Drawing.Size(98, 23);
            this.getSubscriptionsBt.TabIndex = 10;
            this.getSubscriptionsBt.Text = "getSubscriptions";
            this.getSubscriptionsBt.UseVisualStyleBackColor = true;
            this.getSubscriptionsBt.Click += new System.EventHandler(this.getSubscriptionsBt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "endpoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "serverHost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "serverPort";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "channel ID";
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Location = new System.Drawing.Point(155, 72);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(447, 20);
            this.endpointTextBox.TabIndex = 15;
            // 
            // serverHostTextBox
            // 
            this.serverHostTextBox.Location = new System.Drawing.Point(155, 104);
            this.serverHostTextBox.Name = "serverHostTextBox";
            this.serverHostTextBox.Size = new System.Drawing.Size(447, 20);
            this.serverHostTextBox.TabIndex = 16;
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Location = new System.Drawing.Point(155, 139);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(447, 20);
            this.serverPortTextBox.TabIndex = 17;
            // 
            // channelIDTextBox
            // 
            this.channelIDTextBox.Location = new System.Drawing.Point(155, 174);
            this.channelIDTextBox.Name = "channelIDTextBox";
            this.channelIDTextBox.Size = new System.Drawing.Size(447, 20);
            this.channelIDTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "nbLastMessages";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "message";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "convid";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Filter name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Filter attr";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Filter value";
            // 
            // nbLastMessagesTextBox
            // 
            this.nbLastMessagesTextBox.Location = new System.Drawing.Point(155, 212);
            this.nbLastMessagesTextBox.Name = "nbLastMessagesTextBox";
            this.nbLastMessagesTextBox.Size = new System.Drawing.Size(447, 20);
            this.nbLastMessagesTextBox.TabIndex = 26;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(155, 247);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(447, 20);
            this.messageTextBox.TabIndex = 27;
            // 
            // convidTextBox
            // 
            this.convidTextBox.Location = new System.Drawing.Point(155, 281);
            this.convidTextBox.Name = "convidTextBox";
            this.convidTextBox.Size = new System.Drawing.Size(447, 20);
            this.convidTextBox.TabIndex = 28;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(155, 309);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(447, 20);
            this.statusTextBox.TabIndex = 29;
            // 
            // filterNameTextBox
            // 
            this.filterNameTextBox.Location = new System.Drawing.Point(155, 338);
            this.filterNameTextBox.Name = "filterNameTextBox";
            this.filterNameTextBox.Size = new System.Drawing.Size(447, 20);
            this.filterNameTextBox.TabIndex = 30;
            // 
            // filterAttrTextBox
            // 
            this.filterAttrTextBox.Location = new System.Drawing.Point(155, 369);
            this.filterAttrTextBox.Name = "filterAttrTextBox";
            this.filterAttrTextBox.Size = new System.Drawing.Size(447, 20);
            this.filterAttrTextBox.TabIndex = 31;
            // 
            // filterValueTextBox
            // 
            this.filterValueTextBox.Location = new System.Drawing.Point(155, 397);
            this.filterValueTextBox.Name = "filterValueTextBox";
            this.filterValueTextBox.Size = new System.Drawing.Size(447, 20);
            this.filterValueTextBox.TabIndex = 32;
            // 
            // getThreadBt
            // 
            this.getThreadBt.Location = new System.Drawing.Point(13, 536);
            this.getThreadBt.Name = "getThreadBt";
            this.getThreadBt.Size = new System.Drawing.Size(75, 23);
            this.getThreadBt.TabIndex = 33;
            this.getThreadBt.Text = "getThread";
            this.getThreadBt.UseVisualStyleBackColor = true;
            this.getThreadBt.Click += new System.EventHandler(this.getThreadBt_Click);
            // 
            // getThreadsBt
            // 
            this.getThreadsBt.Location = new System.Drawing.Point(99, 535);
            this.getThreadsBt.Name = "getThreadsBt";
            this.getThreadsBt.Size = new System.Drawing.Size(75, 23);
            this.getThreadsBt.TabIndex = 34;
            this.getThreadsBt.Text = "getTreads";
            this.getThreadsBt.UseVisualStyleBackColor = true;
            this.getThreadsBt.Click += new System.EventHandler(this.getThreadsBt_Click);
            // 
            // setFilterBt
            // 
            this.setFilterBt.Location = new System.Drawing.Point(261, 534);
            this.setFilterBt.Name = "setFilterBt";
            this.setFilterBt.Size = new System.Drawing.Size(75, 23);
            this.setFilterBt.TabIndex = 35;
            this.setFilterBt.Text = "setFilter";
            this.setFilterBt.UseVisualStyleBackColor = true;
            this.setFilterBt.Click += new System.EventHandler(this.setFilterBt_Click);
            // 
            // listFilterBt
            // 
            this.listFilterBt.Location = new System.Drawing.Point(342, 534);
            this.listFilterBt.Name = "listFilterBt";
            this.listFilterBt.Size = new System.Drawing.Size(75, 23);
            this.listFilterBt.TabIndex = 36;
            this.listFilterBt.Text = "listFilter";
            this.listFilterBt.UseVisualStyleBackColor = true;
            //this.listFilterBt.Click += new System.EventHandler(this.listFilterBt_Click);
            // 
            // unSetFilterBt
            // 
            this.unSetFilterBt.Location = new System.Drawing.Point(423, 534);
            this.unSetFilterBt.Name = "unSetFilterBt";
            this.unSetFilterBt.Size = new System.Drawing.Size(75, 23);
            this.unSetFilterBt.TabIndex = 37;
            this.unSetFilterBt.Text = "unSetFilter";
            this.unSetFilterBt.UseVisualStyleBackColor = true;
            //this.unSetFilterBt.Click += new System.EventHandler(this.unSetFilterBt_Click);
            // 
            // getRelevantMsgBt
            // 
            this.getRelevantMsgBt.Location = new System.Drawing.Point(504, 534);
            this.getRelevantMsgBt.Name = "getRelevantMsgBt";
            this.getRelevantMsgBt.Size = new System.Drawing.Size(97, 23);
            this.getRelevantMsgBt.TabIndex = 38;
            this.getRelevantMsgBt.Text = "getRelevantMsg";
            this.getRelevantMsgBt.UseVisualStyleBackColor = true;
            this.getRelevantMsgBt.Click += new System.EventHandler(this.getRelevantMsgBt_Click);
            // 
            // commandBt
            // 
            this.commandBt.Location = new System.Drawing.Point(180, 506);
            this.commandBt.Name = "commandBt";
            this.commandBt.Size = new System.Drawing.Size(75, 23);
            this.commandBt.TabIndex = 41;
            this.commandBt.Text = "command";
            this.commandBt.UseVisualStyleBackColor = true;
            //this.commandBt.Click += new System.EventHandler(this.commandBt_Click);
            // 
            // transientRBt
            // 
            this.transientRBt.AutoSize = true;
            this.transientRBt.Location = new System.Drawing.Point(15, 447);
            this.transientRBt.Name = "transientRBt";
            this.transientRBt.Size = new System.Drawing.Size(65, 17);
            this.transientRBt.TabIndex = 42;
            this.transientRBt.TabStop = true;
            this.transientRBt.Text = "persistent";
            this.transientRBt.UseVisualStyleBackColor = true;
            this.transientRBt.Checked = true;
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(638, 9);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(290, 479);
            this.console.TabIndex = 43;
            // 
            // pubConvStateBt
            // 
            this.pubConvStateBt.Location = new System.Drawing.Point(609, 505);
            this.pubConvStateBt.Name = "pubConvStateBt";
            this.pubConvStateBt.Size = new System.Drawing.Size(92, 23);
            this.pubConvStateBt.TabIndex = 44;
            this.pubConvStateBt.Text = "pubConvState";
            this.pubConvStateBt.UseVisualStyleBackColor = true;
            this.pubConvStateBt.Click += new System.EventHandler(this.pubConvStateBt_Click);
            // 
            // radioButton1
            // 
            this.notTransientRBt.AutoSize = true;
            this.notTransientRBt.Location = new System.Drawing.Point(15, 471);
            this.notTransientRBt.Name = "radioButton1";
            this.notTransientRBt.Size = new System.Drawing.Size(83, 17);
            this.notTransientRBt.TabIndex = 45;
            this.notTransientRBt.TabStop = true;
            this.notTransientRBt.Text = "not persistent";
            this.notTransientRBt.UseVisualStyleBackColor = true;
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 577);
            this.Controls.Add(this.notTransientRBt);
            this.Controls.Add(this.pubConvStateBt);
            this.Controls.Add(this.console);
            this.Controls.Add(this.transientRBt);
            this.Controls.Add(this.commandBt);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.getRelevantMsgBt);
            this.Controls.Add(this.unSetFilterBt);
            this.Controls.Add(this.listFilterBt);
            this.Controls.Add(this.setFilterBt);
            this.Controls.Add(this.getThreadsBt);
            this.Controls.Add(this.getThreadBt);
            this.Controls.Add(this.filterValueTextBox);
            this.Controls.Add(this.filterAttrTextBox);
            this.Controls.Add(this.filterNameTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.convidTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.nbLastMessagesTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.channelIDTextBox);
            this.Controls.Add(this.serverPortTextBox);
            this.Controls.Add(this.serverHostTextBox);
            this.Controls.Add(this.endpointTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getSubscriptionsBt);
            this.Controls.Add(this.getLastMsgsBt);
            this.Controls.Add(this.publisherBt);
            this.Controls.Add(this.unsubscribeBt);
            this.Controls.Add(this.subscribeBt);
            this.Controls.Add(this.disconnectBt);
            this.Controls.Add(this.connectBt);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "testForm";
            this.Text = "testForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.TextBox serverHostTextBox;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.TextBox channelIDTextBox;
        private System.Windows.Forms.TextBox nbLastMessagesTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox convidTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox filterNameTextBox;
        private System.Windows.Forms.TextBox filterAttrTextBox;
        private System.Windows.Forms.TextBox filterValueTextBox;

        private System.Windows.Forms.Button connectBt;
        private System.Windows.Forms.Button disconnectBt;
        private System.Windows.Forms.Button subscribeBt;
        private System.Windows.Forms.Button unsubscribeBt;
        private System.Windows.Forms.Button publisherBt;
        private System.Windows.Forms.Button getLastMsgsBt;
        private System.Windows.Forms.Button getSubscriptionsBt;
        private System.Windows.Forms.Button getThreadBt;
        private System.Windows.Forms.Button getThreadsBt;
        private System.Windows.Forms.Button setFilterBt;
        private System.Windows.Forms.Button listFilterBt;
        private System.Windows.Forms.Button unSetFilterBt;
        private System.Windows.Forms.Button getRelevantMsgBt;
        private System.Windows.Forms.Button commandBt;
        private System.Windows.Forms.RadioButton transientRBt;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.Button pubConvStateBt;
        private System.Windows.Forms.RadioButton notTransientRBt;

    }
}